using Moq;
using NUnit.Framework;
using Q1U8BU_HFT_2022231.Logic;
using Q1U8BU_HFT_2022231.Models;
using Q1U8BU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Test
{
    [TestFixture]
    public class Tester
    {
        AuthorLogic authorLogic;
        Mock<IRepository<Author>> mockauthor;
        SongLogic songLogic;
        Mock<IRepository<Song>> mocksong;
        CustomerLogic customerLogic;
        Mock<IRepository<Customer>> mockcustomer;
        SalesLogic salesLogic;
        Mock<IRepository<Sales>> mocksales;
        [SetUp]
        public void Init() {
            mockauthor = new Mock<IRepository<Author>>();
            mockauthor.Setup(m => m.ReadAll()).Returns(new List<Author>()
            {
                new Author("1#Tony Stark"),
                new Author("2#Pepper Potts"),
                new Author("3#Rhodey"),
                new Author("4#Obadiah Stane"),
                new Author("5#Christine Everhart"),
                new Author("6#Yinsen"),
                new Author("7#Raza"),
                new Author("8#Agent Coulson"),
                new Author("9#General Gabriel"),
                new Author("10#Abu Bakaar"),
                new Author("11#JARVIS")
            }.AsQueryable());
            authorLogic = new AuthorLogic(mockauthor.Object);

            mockcustomer = new Mock<IRepository<Customer>>();
            mockcustomer.Setup(m => m.ReadAll()).Returns(new List<Customer>()
            {
                new Customer("1#Varga8#19"),
                new Customer("2#Kovacs#36"),
                new Customer("3#Jakab#39"),
                new Customer("4#Kiss#27"),
                new Customer("5#Ferenci#29"),
                new Customer("6#Nagy#48"),
                new Customer("7#Nemeth#31"),
                new Customer("8#Szabo#28"),
                new Customer("9#Danko#19"),
                new Customer("10#Sziklai#58"),
                new Customer("11#Szoszi#43"),
            }.AsQueryable());
            customerLogic = new CustomerLogic(mockcustomer.Object);

            mocksong = new Mock<IRepository<Song>>();
            mocksong.Setup(m => m.ReadAll()).Returns(new List<Song>()
            {
                new Song("1#Aaron Schwartz#2"),
                new Song("2#Aaron Taylor-Johnson#3"),
                new Song("3#Abby Ryder Fortson#1"),
                new Song("4#Abraham Attah#6"),
                new Song("5#Adewale Akinnuoye-Agbaje#3"),
                new Song("6#Adriana Barraza#4"),
                new Song("7#Alaa Safi#3"),
                new Song("8#Alan Scott#3"),
                new Song("9#Alfred Molina#3"),
                new Song("10#Algenis Perez Soto#4"),
                new Song("11#Alice Krige#3"),
                new Song("12#Amali Golden#2"),
            }.AsQueryable());
            songLogic = new SongLogic(mocksong.Object);


            mocksales = new Mock<IRepository<Sales>>();
            mocksales.Setup(m => m.ReadAll()).Returns(new List<Sales>()
            {
                new Sales("1#Tony Stark#2#3#21210"),
                new Sales("2#Pepper Potts#5#2#21213"),
                new Sales("3#Rhodey#1#4#10110"),
                new Sales("4#Obadiah Stane#2#3#10000"),
                new Sales("5#Christine Everhart#10#11#10101"),
                new Sales("6#Yinsen#5#12#3148"),
                new Sales("7#Raza#9#11#21210"),
                new Sales("8#Agent Coulson#10#2#10001"),
                new Sales("9#General Gabriel#11#7#10133"),
                new Sales("10#Abu Bakaar#2#4#9499"),
                new Sales("11#JARVIS#5#5#55555"),
            }.AsQueryable());
            salesLogic = new SalesLogic(mocksales.Object);

        }
        [Test]
        public void CreateTestSales() 
        {
            
            var test = new Sales("12#Valaki#3#3#21212");
            //Act
            salesLogic.Create(test);
            //Assert
            mocksales.Verify(r => r.Create(test), Times.Once);


        }
        [Test]
        public void CreateTestCustomer()
        {
            var test = new Customer("12#TestCustomer#20");
            //Act
            customerLogic.Create(test);
            //Assert
            mockcustomer.Verify(r => r.Create(test), Times.Once);

        }
        [Test]
        public void CreateTestSong()
        {
            var test = new Song("12#Testmusic#3");
            //Act
            songLogic.Create(test);
            //Assert
            mocksong.Verify(r => r.Create(test), Times.Once);

        }
        [Test]
        public void CreateTestAuthor()
        {
            var test = new Author("12#Authortest");
            //Act
            authorLogic.Create(test);
            //Assert
            mockauthor.Verify(r => r.Create(test), Times.Once);

        }
        [Test]
        public void DeleteTestAuthor()
        {
            //act
            authorLogic.Delete(1);
            //assert
            mockauthor.Verify(r => r.Delete(1), Times.Once);
        }
        [Test]
        public void DeleteTestCustomer()
        {
            //act
            customerLogic.Delete(1);
            //assert
            mockcustomer.Verify(r => r.Delete(1), Times.Once);
        }
        [Test]
        public void DeleteTestSong()
        {
            //act
            songLogic.Delete(1);
            //assert
            mocksong.Verify(r => r.Delete(1), Times.Once);
        }
        [Test]
        public void DeleteTestSongtwo()
        {
            //act
            songLogic.Delete(1);
            //assert
            mocksong.Verify(r => r.Delete(1), Times.Once);
        }
        [Test]
        public void DeleteTestSongthree()
        {
            //act
            songLogic.Delete(1);
            //assert
            mocksong.Verify(r => r.Delete(1), Times.Once);
        }
        [Test]
        public void DeleteTestSongfor()
        {
            //act
            songLogic.Delete(1);
            //assert
            mocksong.Verify(r => r.Delete(1), Times.Once);
        }


    }
}
