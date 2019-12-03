using Potlucky.Controllers;
using Potlucky.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Potlucky.Models;

namespace PotluckyXUnitTestProject
{
    public class MessageTest
    {
        [Fact]
        public void AddMessageTest()
        {
            // Arrange
            var repo = new FakeMessageRepository();
            var messageController = new MessageController(repo);
            var beforeCount = repo.Messages.Count;

            // Act
            messageController.AddMessage("Cora","Molitor",
                "cm@test.com", "Let's Plan Thanksgiving");

            // Assert
            Assert.Equal(beforeCount + 1, repo.Messages.Count);
                
        }

        [Fact]
        public void AddReplyTest()
        {
            //Arrange
            var repo = new FakeMessageRepository();
            var messageController = new MessageController(repo);
            var message = repo.Messages[0];
            var beforeCountR = message.Replies.Count;

            // Act
            messageController.AddReply("Nicolette", "Molitor", "molitorn@my.lanecc.edu",
                                        "I'll bring potatoes", message.MessageId);

            //Assert
            Assert.Equal(beforeCountR + 1, message.Replies.Count);
        }
        [Fact]
        public void IndexSortMessageTest()
        {
            //Arrange
            var repo = new FakeMessageRepository();
            var messageController = new MessageController(repo);


            // Act
            messageController.Index();
            Message message1 = repo.getMessageByDate(DateTime.Parse("8/30/19"));
            Message message2 = repo.getMessageByDate(DateTime.Parse("9/10/19"));
            Message message3 = repo.getMessageByDate(DateTime.Parse("10/20/19"));

            //Assert
            Assert.Equal(repo.Messages[2], message1);
            Assert.Equal(repo.Messages[1], message2);
            Assert.Equal(repo.Messages[0], message3);
        }

    }
}

