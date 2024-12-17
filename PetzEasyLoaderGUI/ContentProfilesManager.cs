using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
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
            if (!config.disableLoadingPetz)
            {
                if (config.gameVersion.Equals("Babyz.exe")) removeBabyzFromGame();
                else removePetzFromGame();
            }

            if (!config.disableLoadingResources) removeResourceFiles(mergeResourecFileFolders(config.exclude, false));
        }

        public void addIncludedFiles()
        {
            if (!config.disableLoadingPetz)
            {
                if (config.gameVersion.Equals("Babyz.exe")) copyBabyzToGame();
                else copyPetzToGame();
            }

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
                        mergedList = mergeSubDirectories(new List<string>(Directory.GetDirectories(resFolder)), removeDupes, mergedList);
                    }
                }

            }
            return mergedList;
        }

        public List<string> mergeSubDirectories(List<string> folderPathsToMerge, bool removeDupes, List<string> mergedList)
        {
            foreach (string subFolder in folderPathsToMerge)
            {
                foreach (string resFile in Directory.GetFiles(subFolder))
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
                mergedList = mergeSubDirectories(new List<string>(Directory.GetDirectories(subFolder)), removeDupes, mergedList);
            }
            return mergedList;
        }

        public void removeResourceFiles(List<string> filesToRemove)
        {
            string gamePath = Path.Combine(config.petzDir, "Resource");
            foreach (string file in filesToRemove)
            {
                string[] fileDirParts = Regex.Split(file, "Resource");
                // remove / from front of string
                string fileDir = fileDirParts[1].Substring(1);

                string fileName = Path.GetFileName(file);
                string gameFile = Path.Combine(gamePath, fileDir);
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
            DirectoryInfo gameDI = new DirectoryInfo(config.petzDir);
            foreach (DirectoryInfo di in gameDI.GetDirectories())
            {
                cleanupSubFolders(di);
            }

        }

        public void cleanupSubFolders(DirectoryInfo directory)
        {
            foreach (DirectoryInfo di in directory.GetDirectories())
            {
                cleanupSubFolders(di);
            }
            if(directory.GetFiles().Length == 0 && directory.GetDirectories().Length == 0)
            {
                directory.Delete();
            }
        }

        public void copyResourceFiles(List<string> filesToCopy)
        {
            string gamePath = Path.Combine(config.petzDir, "Resource");
            foreach (string file in filesToCopy)
            {
                string[] fileDirParts = Regex.Split(file, "Resource");
                // remove / from front of string
                string fileDir = fileDirParts[1].Substring(1);

                string gameFile = Path.Combine(gamePath, fileDir);

                if (!Directory.Exists(Path.GetDirectoryName(gameFile)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(gameFile));
                }
 
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
                                            string guid = getPetGuid(possiblePet);
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
                                    string guid = getPetGuid(petInStorage);
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
                                            string guid = getPetGuid(possiblePet);
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
            string guid1 = getPetGuid(petPath1);
            string guid2 = getPetGuid(petPath2);
            return guid1.Equals(guid2);
        }

        string getPetGuid(string petFile)
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
            if (config.gameVersion.Equals("Babyz.exe")) deleteProfileBabyz(profile);
            else deleteProfilePetz(profile);

            List<string> list = new List<string>();
            list.Add(profile);
            removeResourceFiles(mergeResourecFileFolders(list, false));

            //don't delete petzres resouces, they will get overwritten anyways
        }

        void deleteProfilePetz(string profile)
        {
            string gamePath = Path.Combine(config.petzDir, "Adopted Petz");
            string excludeFolderPath = Path.Combine(fileSource, "ContentProfiles", profile, "Adopted Petz");


            if (Directory.Exists(excludeFolderPath) && Directory.Exists(gamePath))
            {
                foreach (string fileToRemove in Directory.GetFiles(excludeFolderPath))
                {
                    //if file is a pet do extra checks
                    if (Path.GetExtension(fileToRemove).ToLower().Equals(".pet"))
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
                                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(possiblePet, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
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

        void deleteProfileBabyz(string profile)
        {
            string adoptPath = Path.Combine(config.petzDir, "Adopted Babyz");
            string grandmaPath = Path.Combine(config.petzDir, "Grandma's House");

            string excludeFolderPath = Path.Combine(fileSource, "ContentProfiles", profile, "Adopted Babyz");
            if (Directory.Exists(excludeFolderPath) && (Directory.Exists(adoptPath) || Directory.Exists(grandmaPath)))
            {
                foreach (string fileToRemove in Directory.GetFiles(excludeFolderPath))
                {
                    //if file is a baby do extra checks
                    if (Path.GetExtension(fileToRemove).ToLower().Equals(".baby"))
                    {
                        string babyInAdopt = Path.Combine(adoptPath, Path.GetFileName(fileToRemove));
                        string babyGrandma = Path.Combine(grandmaPath, Path.GetFileName(fileToRemove));

                        bool foundBaby = false;
                        //if pet with same name exists check that one first
                        if (File.Exists(babyInAdopt))
                        {
                            if (compareBabyz(fileToRemove, babyInAdopt))
                            {
                                //if we found it, then send to the bin
                                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(babyInAdopt, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                                foundBaby = true;
                            }
                        }
                        //if pet with same name exists check that one first
                        if (!foundBaby && File.Exists(babyGrandma))
                        {
                            if (compareBabyz(fileToRemove, babyGrandma))
                            {
                                //if we found it, then send to the bin
                                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(babyGrandma, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                                foundBaby = true;
                            }
                        }
                        if (!foundBaby)
                        {
                            List<string> babyLoactionList = new List<string>(Directory.GetFiles(adoptPath));
                            babyLoactionList.AddRange(Directory.GetFiles(grandmaPath));
                            // if we haven't found it check every pet
                            foreach (string possiblePet in babyLoactionList)
                            {
                                if (Path.GetExtension(possiblePet).ToLower().Equals(".baby") && compareBabyz(fileToRemove, possiblePet))
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(possiblePet, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                                    break;
                                }
                            }

                        }
                    }
                    else //if it's not a pet just delete it
                    {
                        string fileInGame = Path.Combine(adoptPath, Path.GetFileName(fileToRemove));
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

        void copyBabyzToGame()
        {
            string adoptPath = Path.Combine(config.petzDir, "Adopted Babyz");
            string grandmaPath = Path.Combine(config.petzDir, "Grandma's House");
            foreach (string iFolder in config.include)
            {
                string includeFolderPath = Path.Combine(fileSource, "ContentProfiles", iFolder, "Adopted Babyz");
                if (Directory.Exists(includeFolderPath))
                {
                    foreach (string babyInStorage in Directory.GetFiles(includeFolderPath))
                    {
                        //if baby, we gotta do lots of checks
                        if (Path.GetExtension(babyInStorage).Equals(".baby"))
                        {
                            bool matchFound = false;

                            string babyInAdopt = Path.Combine(adoptPath, Path.GetFileName(babyInStorage)); ;
                            string babyGrandma = Path.Combine(grandmaPath, Path.GetFileName(babyInStorage)); ; 

                            string workingBabyInStorage = babyInStorage;
                            string babyName = Path.GetFileName(babyInStorage);

                            if (File.Exists(babyInAdopt))
                            {
                                // check if they are actually the same baby
                                if (compareBabyz(babyInAdopt, babyInStorage))
                                {
                                    matchFound = true;
                                }
                                else
                                {
                                    //rename the baby in storage so if it's copied in no conflict
                                    string guid = getPetGuid(babyInStorage);
                                    babyName = Path.GetFileNameWithoutExtension(babyInStorage) + "-" + guid.Substring(0, 6) + ".pet";
                                    workingBabyInStorage = Path.Combine(includeFolderPath, babyName);
                                    File.Move(babyInStorage, workingBabyInStorage);
                                }
                            }
                            if (!matchFound && File.Exists(babyInAdopt))
                            {
                                if (compareBabyz(babyInAdopt, babyInStorage))
                                {
                                    matchFound = true;
                                }
                                else
                                {
                                    string guid = getPetGuid(babyInStorage);
                                    babyName = Path.GetFileNameWithoutExtension(babyInStorage) + "-" + guid.Substring(0, 6) + ".pet";
                                    workingBabyInStorage = Path.Combine(includeFolderPath, babyName);
                                    File.Move(babyInStorage, workingBabyInStorage);
                                }
                            }
                            // if we didn't match, check all the babyz
                            if (!matchFound)
                            {
                                List<string> babyLoactionList = new List<string>(Directory.GetFiles(adoptPath));
                                babyLoactionList.AddRange(Directory.GetFiles(grandmaPath));

                                foreach (string possibleBaby in babyLoactionList)
                                {
                                    if (compareBabyz(workingBabyInStorage, possibleBaby))
                                    {
                                        // we found a match with a different name, update the name in storage
                                        string newStoragePath = Path.Combine(includeFolderPath, Path.GetFileName(possibleBaby));
                                        babyName = Path.GetFileName(possibleBaby);

                                        // if a pet with that name is already in storage, append guid to the name of the pet we're working with
                                        if (File.Exists(newStoragePath))
                                        {
                                            string guid = getPetGuid(possibleBaby);
                                            //append guid to in game name
                                            babyName = Path.GetFileNameWithoutExtension(possibleBaby) + "-" + guid.Substring(0, 6) + ".baby";
                                            newStoragePath = Path.Combine(includeFolderPath, babyName);
                                            // rename the pet in game
                                            File.Move(possibleBaby, Path.Combine(Path.GetDirectoryName(possibleBaby), babyName));
                                            // delete the old pet in storage
                                            File.Delete(workingBabyInStorage);
                                            workingBabyInStorage = newStoragePath;
                                        }
                                        // copy the pet with the new name into storage
                                        File.Copy(Path.Combine(Path.GetDirectoryName(possibleBaby), babyName), newStoragePath, true);

                                        matchFound = true;
                                        break;
                                    }
                                }
                            }
                            //still no match, copy the pet in
                            if (!matchFound)
                            {
                                File.Copy(workingBabyInStorage, Path.Combine(adoptPath, babyName), false);
                            }
                        }
                        else
                        {
                            //otherwise just check if it's not there and if not copy it
                            string gameFile = Path.Combine(adoptPath, Path.GetFileName(babyInStorage));
                            if (!(File.Exists(gameFile) && AreSameFile(babyInStorage, gameFile)))
                            {
                                File.Copy(babyInStorage, gameFile, true);
                            }
                        }
                    }

                }
            }
        }

        void removeBabyzFromGame()
        {
            string adoptPath = Path.Combine(config.petzDir, "Adopted Babyz");
            string grandmaPath = Path.Combine(config.petzDir, "Grandma's House");
            foreach (string eFolder in config.exclude)
            {
                string excludeFolderPath = Path.Combine(fileSource, "ContentProfiles", eFolder, "Adopted Babyz");
                if (Directory.Exists(excludeFolderPath))
                {
                    foreach (string fileToRemove in Directory.GetFiles(excludeFolderPath))
                    {
                        //if file is a baby, copy back into folder
                        if (Path.GetExtension(fileToRemove).ToLower().Equals(".baby"))
                        {
                            bool foundBaby = false;

                            string babyInAdopt = Path.Combine(adoptPath, Path.GetFileName(fileToRemove));
                            string babyGrandma = Path.Combine(grandmaPath, Path.GetFileName(fileToRemove));
                            
                            //check adopt
                            if (File.Exists(babyInAdopt))
                            {
                                if (compareBabyz(fileToRemove, babyInAdopt))
                                {
                                    //if same, copy pet to folder then delete pet in game
                                    File.Copy(babyInAdopt, fileToRemove, true);

                                    FileInfo fileInfo = new FileInfo(babyInAdopt);
                                    fileInfo.IsReadOnly = false;
                                    File.Delete(babyInAdopt);
                                    foundBaby = true;
                                }
                            }

                            //check grandma
                            if (!foundBaby && File.Exists(babyGrandma))
                            {
                                if (compareBabyz(fileToRemove, babyGrandma))
                                {
                                    //if same, copy pet to folder then delete pet in game
                                    File.Copy(babyGrandma, fileToRemove, true);

                                    FileInfo fileInfo = new FileInfo(babyGrandma);
                                    fileInfo.IsReadOnly = false;
                                    File.Delete(babyGrandma);
                                    foundBaby = true;
                                }
                            }
                            
                            if (!foundBaby)
                            {
                                // if we haven't found it check every baby
                                List<string> babyLoactionList = new List<string>(Directory.GetFiles(adoptPath));
                                babyLoactionList.AddRange(Directory.GetFiles(grandmaPath));

                                foreach (string possibleBaby in babyLoactionList)
                                {
                                    if (Path.GetExtension(possibleBaby).ToLower().Equals(".baby") && compareBabyz(fileToRemove, possibleBaby))
                                    {
                                        // if we find it, copy pet back into folder with new name
                                        string newStoragePath = Path.Combine(excludeFolderPath, Path.GetFileName(possibleBaby));
                                        if (File.Exists(newStoragePath))
                                        {
                                            // if a pet with the new name exists in storage too, append guid
                                            string guid = getPetGuid(possibleBaby);
                                            newStoragePath = Path.Combine(excludeFolderPath, Path.GetFileNameWithoutExtension(possibleBaby) + "-" + guid.Substring(0, 6) + ".baby");
                                        }
                                        File.Copy(possibleBaby, newStoragePath, true);

                                        // delete the old name pet from storage
                                        FileInfo fileInfo = new FileInfo(fileToRemove);
                                        fileInfo.IsReadOnly = false;
                                        File.Delete(fileToRemove); ;

                                        // and delete pet with new name from game
                                        FileInfo fileInfo2 = new FileInfo(possibleBaby);
                                        fileInfo2.IsReadOnly = false;
                                        File.Delete(possibleBaby);
                                        break;
                                    }
                                }
                            }
                        }
                        else //if it's not a baby just delete it
                        {
                            string fileInGame = Path.Combine(adoptPath, Path.GetFileName(fileToRemove));
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

        bool compareBabyz(string babyPath1, string babyPath2)
        {
            //string guid1 = getPetGuid(babyPath1);
            //string guid2 = getPetGuid(babyPath2);
            //return guid1.Equals(guid2);

            return Path.GetFileName(babyPath1).Equals(Path.GetFileName(babyPath2));
        }
    }
}
