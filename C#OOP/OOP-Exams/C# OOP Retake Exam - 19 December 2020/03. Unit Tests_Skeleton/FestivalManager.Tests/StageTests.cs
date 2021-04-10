// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{

    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
        Stage stage = new Stage();

		[Test]
	    public void ValidateNullValueShouldThrowWhenPerformer()
	    {
            Performer koko = null;

            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(koko);
            });

            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'performer')");

        }

        [Test]
        public void ThrowIfAGEiSlESStHan18()
        {
            Performer koko = new Performer("koko", "boko", 16);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(koko);
            });

            Assert.AreEqual(ex.Message, "You can only add performers that are at least 18.");
        }

        [Test]
        public void IncreaseListCountWhenAdd()
        {
            Performer koko = new Performer("koko", "boko", 22);

            stage.AddPerformer(koko);

            Assert.That(stage.Performers.Count, Is.EqualTo(1));
        }

        [Test]
        public void ValidateNullValueShouldThrowWhenSong()
        {
            Song song = null;

            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(song);
            });

            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'song')");
        }

        [Test]
        public void ThrowWhenLenghtIsLessThan1min()
        {
            Song song = new Song("sen trope", new TimeSpan(0, 0, 30));

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(song);
            });

            Assert.AreEqual(ex.Message, "You can only add songs that are longer than 1 minute.");
        }
        
        [Test]
        public void ShouldAddSongToPerformer()
        {
            Song song = new Song("Azischo", new TimeSpan(0, 1, 30));
            Performer koko = new Performer("Moro", "koki", 22);

            stage.AddPerformer(koko);
            stage.AddSong(song);

            string message = stage.AddSongToPerformer("Azischo", "Moro koki");

            Assert.AreEqual(message, $"{song} will be performed by {koko}");
        }

        [Test]
        public void PlayShouldReturnCorrectMessage()
        {
            Song song = new Song("Azischo", new TimeSpan(0, 1, 30));
            Performer koko = new Performer("Moro", "koki", 22);

            stage.AddPerformer(koko);
            stage.AddSong(song);

            var songsCount = stage.Performers.Sum(p => p.SongList.Count());
            string message = stage.Play();

            Assert.AreEqual(message, $"{stage.Performers.Count} performers played {songsCount} songs");
        }
    }
}