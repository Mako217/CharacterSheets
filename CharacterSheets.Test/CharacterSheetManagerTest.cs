using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CharacterSheets.App;
using CharacterSheets.App.Abstract;
using CharacterSheets.App.Managers;
using CharacterSheets.Domain;
using FluentAssertions;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace CharacterSheets.Test
{
    public class CharacterSheetManagerTest
    {
        private readonly ITestOutputHelper output;

        public CharacterSheetManagerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CanRemoveItem()
        {
            CharacterSheet characterSheet = new WarhammerCharacterSheet() { Id = 1, Name = "Test" };
            List<CharacterSheet> characterSheetList = new List<CharacterSheet>();
            characterSheetList.Add(characterSheet);

            var mock = new Mock<IService<CharacterSheet>>();
            mock.Setup(s => s.RemoveItem(It.IsAny<CharacterSheet>())).Callback<CharacterSheet>((e) => characterSheetList.Remove(e));
            CharacterSheetService.characterSheetSelected = characterSheet;

            CharacterSheetManager characterSheetManager =
                new CharacterSheetManager(new MenuActionService(), mock.Object);

            characterSheetManager.RemoveItem();

            characterSheetList.Should().BeEmpty();
        }

        [Fact]
        public void CanAddWarhammerItem()
        {
            Group group = new Group(1, "Test", GroupType.Warhammer);
            GroupService.groupSelected = group;

            List<CharacterSheet> characterSheetList = new List<CharacterSheet>();

            var mock = new Mock<IService<CharacterSheet>>();
            mock.Setup(s => s.AddItem(It.IsAny<CharacterSheet>())).Callback<CharacterSheet>((e) => characterSheetList.Add(e));
            mock.Setup(s => s.GetNewId()).Returns(1);

            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), mock.Object);


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");

            var stringInput = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringInput);

            manager.AddNewItem();
            WarhammerCharacterSheet characterSheet = (WarhammerCharacterSheet)characterSheetList.FirstOrDefault(s => s.Id == 1);

            characterSheetList.Should().NotBeEmpty();
            characterSheet.Should().NotBeNull();
            output.WriteLine(characterSheet.GetCharacterSheetDetails());


        }

        [Fact]
        public void CanAddSavageWorldsItem()
        {
            Group group = new Group(1, "Test", GroupType.SavageWorlds);
            GroupService.groupSelected = group;

            List<CharacterSheet> characterSheetList = new List<CharacterSheet>();

            var mock = new Mock<IService<CharacterSheet>>();
            mock.Setup(s => s.AddItem(It.IsAny<CharacterSheet>())).Callback<CharacterSheet>((e) => characterSheetList.Add(e));
            mock.Setup(s => s.GetNewId()).Returns(1);

            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), mock.Object);


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("4");
            stringBuilder.AppendLine("4");
            stringBuilder.AppendLine("4");
            stringBuilder.AppendLine("4");
            stringBuilder.AppendLine("4");
            stringBuilder.AppendLine("4");

            var stringInput = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringInput);

            manager.AddNewItem();

            SavageWorldsCharacterSheet characterSheet = (SavageWorldsCharacterSheet)characterSheetList.FirstOrDefault(s => s.Id == 1);

            characterSheetList.Should().NotBeEmpty();
            characterSheet.Should().NotBeNull();
            output.WriteLine(characterSheet.GetCharacterSheetDetails());

        }

        [Fact]
        public void CanAddCthulhuItem()
        {
            Group group = new Group(1, "Test", GroupType.CallOfCthulhu);
            GroupService.groupSelected = group;

            List<CharacterSheet> characterSheetList = new List<CharacterSheet>();

            var mock = new Mock<IService<CharacterSheet>>();
            mock.Setup(s => s.AddItem(It.IsAny<CharacterSheet>())).Callback<CharacterSheet>((e) => characterSheetList.Add(e));
            mock.Setup(s => s.GetNewId()).Returns(1);

            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), mock.Object);


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("Test");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("1");


            var stringInput = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringInput);

            manager.AddNewItem();

            CallOfCthulhuCharacterSheet characterSheet = (CallOfCthulhuCharacterSheet)characterSheetList.FirstOrDefault(s => s.Id == 1);

            characterSheetList.Should().NotBeEmpty();
            characterSheet.Should().NotBeNull();
            output.WriteLine(characterSheet.GetCharacterSheetDetails());

        }

        [Fact]
        public void CanSelectItem()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            WarhammerCharacterSheet characterSheet = new WarhammerCharacterSheet() { Name = "Test", Id = 1, GroupId = 1 };
            List<CharacterSheet> characterSheetList = new List<CharacterSheet>();
            characterSheetList.Add(characterSheet);

            var mock = new Mock<IService<CharacterSheet>>();
            mock.Setup(s => s.GetValidItems()).Returns(characterSheetList);
            mock.Setup(s => s.GetItemById(1)).Returns(characterSheet);

            var input = new StringReader(characterSheet.Id.ToString());
            Console.SetIn(input);
            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), mock.Object);

            manager.SelectItem();

            CharacterSheetService.characterSheetSelected.Should().NotBeNull();
            CharacterSheetService.characterSheetSelected.Should().Be(characterSheet);
        }

        [Fact]
        public void CanEditItem()
        {
            WarhammerCharacterSheet characterSheet = new WarhammerCharacterSheet() { Name = "Test" };
            CharacterSheetService.characterSheetSelected = characterSheet;
            GroupService.groupSelected = new Group(1, "TestGroup", GroupType.Warhammer);

            var mock = new Mock<IService<CharacterSheet>>();

            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), mock.Object);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("TestChanged");
            var stringInput = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringInput);

            manager.EditCharacterSheet();

            characterSheet.Name.Should().Be("TestChanged");
        }

    }
}
