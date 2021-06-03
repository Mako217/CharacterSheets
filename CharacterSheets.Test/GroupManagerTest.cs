using System;
using System.IO;
using System.Linq;
using CharacterSheets.App;
using CharacterSheets.App.Managers;
using CharacterSheets.Domain;
using FluentAssertions;
using Xunit;

namespace CharacterSheets.Test
{
    public class GroupManagerTest
    {
        [Fact]
        public void CanDeleteGroup()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            WarhammerCharacterSheet characterSheet = new WarhammerCharacterSheet()
                {Id = 1, Name = "TestSheet", GroupId = 1};
            CharacterSheetService characterSheetService = new CharacterSheetService();
            GroupService groupService = new GroupService();

            characterSheetService.AddItem(characterSheet);
            groupService.AddItem(group);
            characterSheetService.groupSelected = group;

            var manager = new GroupManager(new MenuActionService(), groupService, characterSheetService);

            manager.RemoveItem();

            characterSheetService.GetCharacterSheetByGroup().Should().BeEmpty();
            groupService.GetItemById(group.Id).Should().BeNull();
        }

        [Fact]
        public void CanAddGroup()
        {
            var input = new StringReader("Test");
            Console.SetIn(input);
            GroupService groupService = new GroupService();

            GroupManager manager = new GroupManager(new MenuActionService(), groupService, new CharacterSheetService());

            int resultId = manager.AddNewItem();

            groupService.Items.Should().NotBeEmpty();
            groupService.GetItemById(resultId).Should().NotBeNull();
            groupService.Items.FirstOrDefault(p => p.Name == "Test").Should().NotBeNull();

        }

        [Fact]
        public void CanSelectItem()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            GroupService groupService = new GroupService();
            groupService.AddItem(group);
            groupService.typeSelected = GroupType.Warhammer;

            CharacterSheetService characterSheetService = new CharacterSheetService();


            var input = new StringReader(group.Id.ToString());
            Console.SetIn(input);
            GroupManager manager = new GroupManager(new MenuActionService(), groupService, characterSheetService);

            manager.SelectItem();

            characterSheetService.groupSelected.Should().NotBeNull();
            characterSheetService.groupSelected.Should().Be(group);
        }
    }
}
