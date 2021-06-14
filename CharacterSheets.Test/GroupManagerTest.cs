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
            { Id = 1, Name = "TestSheet", GroupId = 1 };
            List<CharacterSheet> characterSheetList = new List<CharacterSheet>();
            characterSheetList.Add(characterSheet);

            var mockGroup = new Mock<IService<Group>>();
            GroupService.groupSelected = group;
            mockGroup.Setup(s => s.RemoveItem(It.IsAny<Group>())).Callback<Group>((e) => groupList.Remove(e));

            var mockCharacterSheet = new Mock<IService<CharacterSheet>>();
            mockCharacterSheet.Setup(s => s.GetValidItems()).Returns(characterSheetList);
            mockCharacterSheet.Setup(s => s.RemoveItem(It.IsAny<CharacterSheet>())).Callback<CharacterSheet>((e) => characterSheetList.Remove(e));

            var manager = new GroupManager(new MenuActionService(), mockGroup.Object, mockCharacterSheet.Object);

            groupList.Should().NotBeEmpty();
            characterSheetList.Should().NotBeEmpty();

            manager.RemoveItem();

            groupList.Should().BeEmpty();
            characterSheetList.Should().BeEmpty();
        }

        [Fact]
        public void CanAddGroup()
        {
            var input = new StringReader("Test");
            Console.SetIn(input);

            List<Group> groupList = new List<Group>();

            var mockGroup = new Mock<IService<Group>>();
            mockGroup.Setup(s => s.AddItem(It.IsAny<Group>())).Callback<Group>((e) => groupList.Add(e));
            mockGroup.Setup(s => s.GetNewId()).Returns(1);

            var mockCharacterSheet = new Mock<IService<CharacterSheet>>();

            GroupManager manager = new GroupManager(new MenuActionService(), mockGroup.Object, mockCharacterSheet.Object);

            int resultId = manager.AddNewItem();

            groupList.Should().NotBeEmpty();
            groupList.FirstOrDefault(p => p.Id == 1).Should().NotBeNull();
            groupList.FirstOrDefault(p => p.Name == "Test").Should().NotBeNull();

        }

        [Fact]
        public void CanSelectItem()
        {
            Group group = new Group(1, "TestGroup", GroupType.Warhammer);
            List<Group> groupList = new List<Group>();
            groupList.Add(group);

            var mockGroup = new Mock<IService<Group>>();
            mockGroup.Setup(s => s.GetValidItems()).Returns(groupList);
            mockGroup.Setup(s => s.GetItemById(1)).Returns(group);

            var mockCharacterSheet = new Mock<IService<CharacterSheet>>();

            var input = new StringReader(group.Id.ToString());
            Console.SetIn(input);
            GroupManager manager = new GroupManager(new MenuActionService(), mockGroup.Object, mockCharacterSheet.Object);

            manager.SelectItem();

            GroupService.groupSelected.Should().NotBeNull();
            GroupService.groupSelected.Should().Be(group);
        }
    }
}
