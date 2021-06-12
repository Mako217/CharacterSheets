using System;
using System.IO;
using System.Text;
using CharacterSheets.App;
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
            CharacterSheetService characterSheetService = new CharacterSheetService(null);
            CharacterSheet characterSheet = new WarhammerCharacterSheet() {Id = 1, Name = "Test"};
            characterSheetService.AddItem(characterSheet);
            CharacterSheetService.characterSheetSelected = characterSheet;

            CharacterSheetManager characterSheetManager =
                new CharacterSheetManager(new MenuActionService(), characterSheetService);

            characterSheetManager.RemoveItem();

            characterSheetService.GetItemById(characterSheet.Id).Should().BeNull();
        }

        [Fact]
        public void CanAddWarhammerItem()
        {
            CharacterSheetService service = new CharacterSheetService(null);
            Group group = new Group(1, "Test", GroupType.Warhammer);
            GroupService.groupSelected = group;

            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), service);


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

            WarhammerCharacterSheet characterSheet = (WarhammerCharacterSheet) service.GetItemById(1);

            service.Items.Should().NotBeEmpty();
            characterSheet.Should().NotBeNull();
            output.WriteLine(characterSheet.GetCharacterSheetDetails());


        }

        [Fact]
        public void CanAddSavageWorldsItem()
        {
            CharacterSheetService service = new CharacterSheetService(null);
            Group group = new Group(1, "Test", GroupType.SavageWorlds);
            GroupService.groupSelected = group;

            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), service);


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

            SavageWorldsCharacterSheet characterSheet = (SavageWorldsCharacterSheet)service.GetItemById(1);

            service.Items.Should().NotBeEmpty();
            characterSheet.Should().NotBeNull();
            output.WriteLine(characterSheet.GetCharacterSheetDetails());

        }

        [Fact]
        public void CanAddCthulhuItem()
        {
            CharacterSheetService service = new CharacterSheetService(null);
            Group group = new Group(1, "Test", GroupType.CallOfCthulhu);
            GroupService.groupSelected = group;

            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), service);


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

            CallOfCthulhuCharacterSheet characterSheet = (CallOfCthulhuCharacterSheet)service.GetItemById(1);

            service.Items.Should().NotBeEmpty();
            characterSheet.Should().NotBeNull();
            output.WriteLine(characterSheet.GetCharacterSheetDetails());

        }

        [Fact]
        public void CanSelectItem()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            WarhammerCharacterSheet characterSheet = new WarhammerCharacterSheet() {Name = "Test", Id = 1, GroupId = 1};
            CharacterSheetService characterSheetService = new CharacterSheetService(null);
            characterSheetService.AddItem(characterSheet);
            GroupService.groupSelected = group;


            var input = new StringReader(characterSheet.Id.ToString());
            Console.SetIn(input);
            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), characterSheetService);

            manager.SelectItem();

            CharacterSheetService.characterSheetSelected.Should().NotBeNull();
            CharacterSheetService.characterSheetSelected.Should().Be(characterSheet);
        }

        [Fact]
        public void CanEditItem()
        {
            WarhammerCharacterSheet characterSheet = new WarhammerCharacterSheet() { Name = "Test" };
            CharacterSheetService service = new CharacterSheetService(null);
            CharacterSheetService.characterSheetSelected = characterSheet;
            GroupService.groupSelected = new Group(1, "TestGroup", GroupType.Warhammer);
            CharacterSheetManager manager = new CharacterSheetManager(new MenuActionService(), service);

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
