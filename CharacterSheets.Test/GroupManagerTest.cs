using System;
using System.IO;
using System.Linq;
using CharacterSheets.App;
using CharacterSheets.App.Managers;
using CharacterSheets.Domain;
using FluentAssertions;
using Xunit;
using Moq;
using System.Collections.Generic;
using CharacterSheets.App.Abstract;

namespace CharacterSheets.Test
{
    public class GroupManagerTest
    {
        [Fact]
        public void CanDeleteGroup()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            List<Group> groupList = new List<Group>();
            groupList.Add(group);

            WarhammerCharacterSheet characterSheet = new WarhammerCharacterSheet()
                {Id = 1, Name = "TestSheet", GroupId = 1};
            List<CharacterSheet> characterSheetList = new List<CharacterSheet>();
            characterSheetList.Add(characterSheet);

            var mockGroup = new Mock<IService<Group>>();
            GroupService.groupSelected = group;
            mockGroup.Setup(s => s.Items).Returns(groupList);
            mockGroup.Setup(s => s.RemoveItem(It.IsAny<Group>())).Callback<Group>((e) => mockGroup.Object.Items.Remove(e));

            var mockCharacterSheet = new Mock<IService<CharacterSheet>>();
            mockCharacterSheet.Setup(s => s.Items).Returns(characterSheetList);
            mockCharacterSheet.Setup(s => s.GetValidItems()).Returns(characterSheetList);
            mockCharacterSheet.Setup(s => s.RemoveItem(It.IsAny<CharacterSheet>())).Callback<CharacterSheet>((e) => mockCharacterSheet.Object.Items.Remove(e));

            var manager = new GroupManager(new MenuActionService(), mockGroup.Object, mockCharacterSheet.Object);

            mockGroup.Object.Items.Should().NotBeEmpty();
            mockCharacterSheet.Object.Items.Should().NotBeEmpty();

            manager.RemoveItem();

            mockGroup.Object.Items.Should().BeEmpty();
            mockCharacterSheet.Object.Items.Should().BeEmpty();
        }

        [Fact]
        public void CanAddGroup()
        {
            var input = new StringReader("Test");
            Console.SetIn(input);
            GroupService groupService = new GroupService(null);

            GroupManager manager = new GroupManager(new MenuActionService(), groupService, new CharacterSheetService(null));

            int resultId = manager.AddNewItem();

            groupService.Items.Should().NotBeEmpty();
            groupService.GetItemById(resultId).Should().NotBeNull();
            groupService.Items.FirstOrDefault(p => p.Name == "Test").Should().NotBeNull();

        }

        [Fact]
        public void CanSelectItem()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            GroupService groupService = new GroupService(null);
            groupService.AddItem(group);
            GroupService.typeSelected = GroupType.Warhammer;

            CharacterSheetService characterSheetService = new CharacterSheetService(null);


            var input = new StringReader(group.Id.ToString());
            Console.SetIn(input);
            GroupManager manager = new GroupManager(new MenuActionService(), groupService, characterSheetService);

            manager.SelectItem();

            GroupService.groupSelected.Should().NotBeNull();
            GroupService.groupSelected.Should().Be(group);
        }

        [Fact]
        public void TestingMoq()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            List<Group> groupList = new List<Group>();
            groupList.Add(group);

            var mock = new Mock<IService<Group>>();
            mock.Setup(s => s.Items).Returns(groupList);

            mock.Setup(s => s.RemoveItem(It.IsAny<Group>())).Callback<Group>((e) => mock.Object.Items.Remove(e));

            mock.Object.Items.Should().NotBeEmpty();

            mock.Object.RemoveItem(group);

            mock.Object.Items.Should().BeEmpty();
        }
    }
}
