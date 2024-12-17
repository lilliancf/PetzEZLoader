using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzEasyLoaderGUI
{
    internal class ContentProfilesManager
    {
        configProperties config;
        string fileSource = Path.Combine(System.AppContext.BaseDirectory, "Filez");

        public ContentProfilesManager(configProperties cfg)
        {
            this.config = cfg;
        }

        public void loadBaseGameFiles()
        {
            if (!Directory.Exists(Path.Combine(fileSource, "ContentProfiles", "baseGameBackup"))) 
                Program.regenerateBaseGameBackup(config.gameVersion);
            //check config again in case loading failed
            if(!config.disableLoadingResources)
                copyResourceFiles(mergeResourecFileFolders(new List<string>() { "baseGameBackup" }, true));
        }

        public void removeExcludedFiles()
        {
            if (!config.disableLoadingPetz) removePetzFromGame();
            if (!config.disableLoadingResources) removeResourceFiles(mergeResourecFileFolders(config.exclude, false));
        }

        public void addIncludedFiles()
        {
            if (!config.disableLoadingPetz) copyPetzToGame();
            if (!config.disableLoadingResources)  copyResourceFiles(mergeResourecFileFolders(config.include, true));

            List<string> includeList = new List<string>(config.include);
            if (!config.disableBaseGameFallback)
            {
                if (!Directory.Exists(Path.Combine(fileSource, "ContentProfiles", "baseGameBackup"))) 
                    Program.regenerateBaseGameBackup(config.gameVersion);
                //check config again in case loading failed
                if (!config.disableLoadingResources)
                    includeList = config.include.Prepend("baseGameBackup").ToList();
            }

            if (!config.disableLoadingCase) loadLastResource("CarryingCase", includeList);
            if (!config.disableLoadingAC) loadLastResource("ACSprites", includeList);
            if (!config.disableLoadingMice) loadLastResource("Mice", includeList);
        }

        public List<string> mergeResourecFileFolders(List<string> foldersToMerge, bool removeDupes)
        {
            List<string> mergedList = new List<string>();
            foreach (string folderName in foldersToMerge)
            {
                string storageResPath = Path.Combine(fileSource, "ContentProfiles", folderName, "Resource");
                if (Directory.Exists(storageResPath))
                {
                    foreach (string resFolder in Directory.GetDirectories(Path.Combine(fileSource, "ContentProfiles", folderName, "Resource")))
                    {
                        foreach (string resFile in Directory.GetFiles(resFolder))
                        {
                            if (removeDupes)
                            {
                                IEnumerable<string> dupeFiles = mergedList.Where<string>(item => Path.GetFileName(item) == Path.GetFileName(resFile));
                                foreach (string dupe in dupeFiles.ToList())
                                {
                                    mergedList.Remove(dupe);
                                }
                            }
                            mergedList.Add(resFile);
                        }
                    }
                }

            }
            return mergedList;
        }

        public void removeResourceFiles(List<string> filesToRemove)
        {
            string gamePath = Path.Combine(config.petzDir, "Resource");
            foreach (string file in filesToRemove)
            {
                string fileDir = Path.GetFileName(Path.GetDirectoryName(file));
                string fileName = Path.GetFileName(file);
                string gameFile = Path.Combine(gamePath, fileDir, fileName);
                if (File.Exists(gameFile))
                {
                    if (AreSameFile(file, gameFile))
                    {
                        FileInfo fileInfo = new FileInfo(gameFile);
                        fileInfo.IsReadOnly = false;
                        File.Delete(gameFile);
                    }
                }
            }
        }

        public void copyResourceFiles(List<string> filesToCopy)
        {
            string gamePath = Path.Combine(config.petzDir, "Resource");
            foreach (string file in filesToCopy)
            {
                string fileDir = Path.GetFileName(Path.GetDirectoryName(file));

                if (!Directory.Exists(Path.Combine(gamePath, fileDir)))
                {
                    Directory.CreateDirectory(Path.Combine(gamePath, fileDir));
                }

                string fileName = Path.GetFileName(file);
                string gameFile = Path.Combine(gamePath, fileDir, fileName);
                if (!(File.Exists(gameFile) && AreSameFile(file, gameFile)))
                {
                    File.Copy(file, gameFile, true);
                }

            }
        }

        bool AreSameFile(string path1, string path2)
        {
            FileInfo file1 = new FileInfo(path1);
            FileInfo file2 = new FileInfo(path2);

            return file1.Name == file2.Name && file1.Length == file2.Length && file1.LastWriteTime == file2.LastWriteTime;
        }

        void loadLastResource(string type, List<string> includeList)
        {
            string gamePath = "";
            if (type.Equals("CarryingCase"))
                gamePath = Path.Combine(config.petzDir, "Art", "Sprites", "Case");
            else if (type.Equals("ACSprites"))
                gamePath = Path.Combine(config.petzDir, "Art", "Sprites", "Adpt");
            else if (type.Equals("Mice"))
                gamePath = Path.Combine(config.petzDir, "PtzFiles", "Mouse");
            else
                return;

            Directory.CreateDirectory(gamePath);

            string lastDir = "";
            foreach (string profile in includeList)
            {
                string storagePath = Path.Combine(fileSource, "ContentProfiles", profile, type);
                if (Directory.Exists(storagePath))
                {
                    lastDir = storagePath;
                }
            }
            if (!String.IsNullOrEmpty(lastDir))
            {
                foreach (string file in Directory.GetFiles(lastDir))
                {
                    string copyPath = Path.Combine(gamePath, Path.GetFileName(file));
                    File.Copy(file, copyPath, true);
                }
            }
        }

        void removePetzFromGame()
        {
            string gamePath = Path.Combine(config.petzDir, "Adopted Petz");
            foreach (string eFolder in config.exclude)
            {
                string excludeFolderPath = Path.Combine(fileSource, "ContentProfiles", eFolder, "Adopted Petz");
                if (Directory.Exists(excludeFolderPath))
                {
                    foreach (string fileToRemove in Directory.GetFiles(excludeFolderPath))
                    {
                        //if file is a pet, copy back into folder
                        if (Path.GetExtension(fileToRemove).ToLower().Equals(".pet"))
                        {
                            string petInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                            bool foundPet = false;
                            //if pet with same name exists check that one first
                            if (File.Exists(petInGame))
                            {
                                if (comparePetz(fileToRemove, petInGame))
                                {
                                    //if same, copy pet to folder then delete pet in game
                                    File.Copy(petInGame, fileToRemove, true);

                                    FileInfo fileInfo = new FileInfo(petInGame);
                                    fileInfo.IsReadOnly = false;
                                    File.Delete(petInGame);
                                    foundPet = true;
                                }
                            }
                            if (!foundPet)
                            {
                                // if we haven't found it check every pet
                                foreach (string possiblePet in Directory.GetFiles(gamePath))
                                {
                                    if (Path.GetExtension(possiblePet).ToLower().Equals(".pet") && comparePetz(fileToRemove, possiblePet))
                                    {
                                        // if we find it, copy pet back into folder with new name
                                        string newStoragePath = Path.Combine(excludeFolderPath, Path.GetFileName(possiblePet));
                                        if (File.Exists(newStoragePath))
                                        {
                                            // if a pet with the new name exists in storage too, append guid
                                            string guid = getGuid(possiblePet);
                                            newStoragePath = Path.Combine(excludeFolderPath, Path.GetFileNameWithoutExtension(possiblePet) + "-" + guid.Substring(0, 6) + ".pet");
                                        }
                                        File.Copy(possiblePet, newStoragePath, true);

                                        // delete the old name pet from storage
                                        FileInfo fileInfo = new FileInfo(fileToRemove);
                                        fileInfo.IsReadOnly = false;
                                        File.Delete(fileToRemove); ;

                                        // and delete pet with new name from game
                                        FileInfo fileInfo2 = new FileInfo(possiblePet);
                                        fileInfo2.IsReadOnly = false;
                                        File.Delete(possiblePet);
                                        break;
                                    }
                                }
                            }
                        }
                        else //if it's not a pet just delete it
                        {
                            string fileInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                            if (File.Exists(fileInGame))
                            {
                                FileInfo fileInfo = new FileInfo(fileInGame);
                                fileInfo.IsReadOnly = false;
                                File.Delete(fileInGame);
                            }
                        }



                    }
                }
            }
        }

        void copyPetzToGame()
        {
            string gamePath = Path.Combine(config.petzDir, "Adopted Petz");
            foreach (string iFolder in config.include)
            {
                string includeFolderPath = Path.Combine(fileSource, "ContentProfiles", iFolder, "Adopted Petz");
                if (Directory.Exists(includeFolderPath))
                {
                    foreach (string petInStorage in Directory.GetFiles(includeFolderPath))
                    {
                        //if pet, we gotta do lots of checks
                        if (Path.GetExtension(petInStorage).Equals(".pet"))
                        {
                            bool matchFound = false;
                            string petInGame = Path.Combine(gamePath, Path.GetFileName(petInStorage));
                            string workingPetInStorage = petInStorage;
                            string petName = Path.GetFileName(petInStorage);
                            // if a name match, check that first
                            if (File.Exists(petInGame))
                            {
                                // check if they are actually the same pet
                                if (comparePetz(petInGame, petInStorage))
                                {
                                    matchFound = true;
                                }
                                else
                                {
                                    //rename the pet in storage so if it's copied in no conflict
                                    string guid = getGuid(petInStorage);
                                    petName = Path.GetFileNameWithoutExtension(petInStorage) + "-" + guid.Substring(0, 6) + ".pet";
                                    workingPetInStorage = Path.Combine(includeFolderPath, petName);
                                    File.Move(petInStorage, workingPetInStorage);

                                }
                            }
                            // if we didn't match, check all the petz
                            if (!matchFound)
                            {
                                foreach (string possiblePet in Directory.GetFiles(gamePath))
                                {
                                    if (comparePetz(workingPetInStorage, possiblePet))
                                    {
                                        // we found a match with a different name, update the name in storage
                                        string newStoragePath = Path.Combine(includeFolderPath, Path.GetFileName(possiblePet));
                                        petName = Path.GetFileName(possiblePet);

                                        // if a pet with that name is already in storage, append guid to the name of the pet we're working with
                                        if (File.Exists(newStoragePath))
                                        {
                                            string guid = getGuid(possiblePet);
                                            //append guid to in game name
                                            petName = Path.GetFileNameWithoutExtension(possiblePet) + "-" + guid.Substring(0, 6) + ".pet";
                                            newStoragePath = Path.Combine(includeFolderPath, petName);
                                            // rename the pet in game
                                            File.Move(possiblePet, Path.Combine(gamePath, petName));
                                            // delete the old pet in storage
                                            File.Delete(workingPetInStorage);
                                            workingPetInStorage = newStoragePath;
                                        }
                                        // copy the pet with the new name into storage
                                        File.Copy(Path.Combine(gamePath, petName), newStoragePath, true);

                                        matchFound = true;
                                        break;
                                    }
                                }
                            }
                            //still no match, copy the pet in
                            if (!matchFound)
                            {
                                File.Copy(workingPetInStorage, Path.Combine(gamePath, petName), false);
                            }
                        }
                        else
                        {
                            //otherwise just check if it's not there and if not copy it
                            string gameFile = Path.Combine(gamePath, Path.GetFileName(petInStorage));
                            if (!(File.Exists(gameFile) && AreSameFile(petInStorage, gameFile)))
                            {
                                File.Copy(petInStorage, gameFile, true);
                            }
                        }
                    }

                }
            }
        }

        bool comparePetz(string petPath1, string petPath2)
        {
            string guid1 = getGuid(petPath1);
            string guid2 = getGuid(petPath2);
            return guid1.Equals(guid2);
        }

        string getGuid(string petFile)
        {
            byte[] petBytes = File.ReadAllBytes(petFile);
            byte[] pfmstr = Encoding.ASCII.GetBytes("PfMaGiCpEtZIII");
            int index = searchBytes(petBytes, pfmstr);

            int guidStart = index + pfmstr.Length + 5;
            byte[] guid = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                byte b = petBytes[guidStart++];
                guid[i] = b;
            }
            return new Guid(guid).ToString();
        }
        
        int searchBytes(byte[] haystack, byte[] needle)
        {
            var len = needle.Length;
            var limit = haystack.Length - len;
            for (var i = 0; i <= limit; i++)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (needle[k] != haystack[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }

        public void deleteContentProfile(string profile)
        {
            string gamePath = Path.Combine(config.petzDir, "Adopted Petz");
            string excludeFolderPath = Path.Combine(fileSource, "ContentProfiles", profile, "Adopted Petz");


            if (Directory.Exists(excludeFolderPath) && Directory.Exists(gamePath))
            {
                foreach (string fileToRemove in Directory.GetFiles(excludeFolderPath))
                {
                    //if file is a pet do extra checks
                    if (Path.GetExtension(fileToRemove).ToLower().Equals("pet"))
                    {
                        string petInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                        bool foundPet = false;
                        //if pet with same name exists check that one first
                        if (File.Exists(petInGame))
                        {
                            if (comparePetz(fileToRemove, petInGame))
                            {
                                //if we found it, then send to the bin
                                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(petInGame, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            }
                        }
                        if (!foundPet)
                        {
                            // if we haven't found it check every pet
                            foreach (string possiblePet in Directory.GetFiles(gamePath))
                            {
                                if (Path.GetExtension(possiblePet).ToLower().Equals(".pet") && comparePetz(fileToRemove, possiblePet))
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(petInGame, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                                    break;
                                }
                            }
                        }
                    }
                    else //if it's not a pet just delete it
                    {
                        string fileInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                        if (File.Exists(fileInGame))
                        {
                            FileInfo fileInfo = new FileInfo(fileInGame);
                            fileInfo.IsReadOnly = false;
                            File.Delete(fileInGame);
                        }
                    }
                }
            }

            List<string> list = new List<string>();
            list.Add(profile);
            removeResourceFiles(mergeResourecFileFolders(list, false));

            //don't delete petzres resouces, they will get overwritten anyways
        }

    }
}
