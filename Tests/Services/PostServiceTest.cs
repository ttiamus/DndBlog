using System;
using System.Linq;
using Blog.DAL;
using Blog.Models;
using Blog.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL.Tests.Services
{
    [TestClass]
    public class JournalServiceTest
    {
        [TestMethod]
        public void CanSaveEntry()
        {
            var entry = new JournalEntry("UnitTestEntry", "test title", "Ttiamus");
            JournalService entryService = new JournalService();

            var insertTask = entryService.CreateEntry(entry);

            Assert.IsTrue(insertTask.Result);
        }

        [TestMethod]
        public void CanGetAllEntries()
        {
            JournalService entryService = new JournalService();

            var entryToInsert = new JournalEntry("CanGetAllEntries", "test title", "Ttiamus");
            entryService.CreateEntry(entryToInsert).Wait();

            var getAllEntryTask = entryService.GetEntries();
            var entries = getAllEntryTask.Result.ToList();
            Assert.IsTrue(entries.Count > 0);
        }

        [TestMethod]
        public void CanGetTopEntries()
        {
            JournalService entryService = new JournalService();

            var entryToInsert = new JournalEntry("CanGetAllEntries", "test title", "Ttiamus");

            for (var i = 0; i <= 5; i++)
            {
                entryService.CreateEntry(entryToInsert).Wait();
            }

            var getAllEntryTask = entryService.GetEntries("Ttiamus", 0);
            var entries = getAllEntryTask.Result.ToList();
            Assert.IsTrue(entries.Count == 5);
        }


        [TestMethod]
        public void CanGetEntry()
        {
            JournalService entryService = new JournalService();

            var entryToInsert = new JournalEntry("UnitTestEntry", "test title", "Ttiamus");

            entryService.CreateEntry(entryToInsert).Wait();

            var entry = entryService.GetEntry(entryToInsert.Id).Result;

            Assert.IsTrue(string.Equals(entry.Id, entryToInsert.Id));
        }

        [TestMethod]
        public void CanUpdateEntry()
        {
            JournalService entryService = new JournalService(); ;

            var entryToUpdate = new JournalEntry("Entry To Update", "test title", "Ttiamus");
            entryService.CreateEntry(entryToUpdate).Wait();

            var entry = new JournalEntry("CanUpdateEntryTest", "test title", "Ttiamus") {Id = entryToUpdate.Id };


            var updateEntryTask = entryService.UpdateEntry(entry);
            updateEntryTask.Wait();
            Assert.AreEqual("CanUpdateEntryTest", entryService.GetEntry(entryToUpdate.Id).Result.Body);
        }

        [TestMethod]
        public void CanDeleteEntry()
        {
            JournalService entryService = new JournalService();
            var entry = new JournalEntry("CanDeleteEntry test", "test title", "Ttiamus");
            entryService.CreateEntry(entry).Wait();

            var deleteEntryTask = entryService.DeleteEntry(entry.Id);
            deleteEntryTask.Wait();
            Assert.IsNull(entryService.GetEntry(entry.Id).Result);
        }
    }
}