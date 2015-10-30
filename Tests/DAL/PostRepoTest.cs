using System;
using System.Linq;
using System.Runtime.Serialization;
using Blog.DAL;
using Blog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace Tests.DAL
{
    [TestClass]
    public class JournalRepoTest
    {
        [TestMethod]
        public void CanSaveEntry()
        {
            var entry = new JournalEntry("UnitTestEntry", "test title", "Ttiamus");
            var entryRepo = new JournalRepo();
            var insertTask = entryRepo.CreateEntry(entry);
            insertTask.Wait();

            Assert.IsTrue(insertTask.IsCompleted);
        }

        [TestMethod]
        public void CanGetAllEntries()
        {
            var entryRepo = new JournalRepo();

            var entryToInsert = new JournalEntry("CanGetAllEntries", "test title", "Ttiamus");
            entryRepo.CreateEntry(entryToInsert).Wait();

            var getAllEntriesTask = entryRepo.GetEntries();
            var entries = getAllEntriesTask.Result.ToList();
            Assert.IsTrue(entries.Count > 0);
        }

        [TestMethod]
        public void CanGetTopEntries()
        {
            var entryRepo = new JournalRepo();

            var entryToInsert = new JournalEntry("CanGetTopEntriesTest", "test title", "Ttiamus");

            for (var i = 0; i <= 5; i++)
            {
                entryRepo.CreateEntry(entryToInsert).Wait();
            }

            var getTopEntriesTask = entryRepo.GetEntries("Ttiamus", 0);
            var entries = getTopEntriesTask.Result.ToList();
            Assert.IsTrue(entries.Count == 5);
        }

        [TestMethod]
        public void CanGetEntry()
        {
            var entryRepo = new JournalRepo();

            var entryToInsert = new JournalEntry("UnitTestEntry", "test title", "Ttiamus");

            entryRepo.CreateEntry(entryToInsert).Wait();

            var entry = entryRepo.GetEntry(entryToInsert.Id).Result;

            var id1 = entryToInsert.Id;
            var id2 = entry.Id;
            var test = string.Equals(id1, id2);
            Assert.IsTrue(string.Equals(entry.Id, entryToInsert.Id));
        }

        [TestMethod]
        public void CanUpdateEntry()
        {
            var entryRepo = new JournalRepo();

            var entryToUpdate = new JournalEntry("Entry To Update", "test title", "Ttiamus");
            entryRepo.CreateEntry(entryToUpdate).Wait();

            var entry = new JournalEntry("CanUpdateEntryTest", "test title", "Ttiamus") {Id = entryToUpdate.Id};


            var updateEntryTask = entryRepo.UpdateEntry(entry);
            updateEntryTask.Wait();
            Assert.AreEqual("CanUpdateEntryTest", entryRepo.GetEntry(entryToUpdate.Id).Result.Body);
        }

        [TestMethod]
        public void CanDeleteEntry()
        {
            var entryRepo = new JournalRepo();
            var entry = new JournalEntry("CanDeleteEntry test", "test title", "Ttiamus");
            entryRepo.CreateEntry(entry).Wait();

            var deleteEntryTask = entryRepo.DeleteEntry(entry.Id);
            deleteEntryTask.Wait();
            Assert.IsNull(entryRepo.GetEntry(entry.Id).Result);
        }
    }

}