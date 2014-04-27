using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDevign.M3.CAVM.Controls;

namespace IDevign.M3.CAVM.Specifications
{
    [TestClass]
    public class PictureViewerSpecs
    {
        [TestMethod]
        public void Given_An_ImageList_When_Changing_Order_Should_Move_FirstEntry_To_End_Of_List()
        {
            // Arrange
            var viewModel = new PictureViewerViewModel();
            viewModel.ImageList = new ObservableCollection<string>
                {
                    "Entry_1",
                    "Entry_2",
                    "Entry_3",
                    "Entry_4",
                    "Entry_5"
                };

            // Act
            viewModel.ChangeOrderCommand.Execute(SortDirection.Reversed);

            // Assert
            string newLastEntry = viewModel.ImageList.Last();
            Assert.AreEqual(newLastEntry, "Entry_1", false, "Collection was not reversed by ViewModelCommand!");
        }

        [TestMethod]
        public void Given_An_ImageList_When_Changing_Order_Should_Set_SortDirection_ToReversed()
        {
            // Arrange
            var viewModel = new PictureViewerViewModel();
            viewModel.ImageList = new ObservableCollection<string>
                {
                    "Entry_1"
                };

            // Act
            viewModel.ChangeOrderCommand.Execute(SortDirection.Reversed);

            // Assert
            Assert.AreEqual(viewModel.CurrentListSortDirection, SortDirection.Reversed, "SortDirection was not changed!");
        }
    }
}
