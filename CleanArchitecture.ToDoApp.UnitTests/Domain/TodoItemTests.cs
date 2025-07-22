using CleanArchitecture.ToDoApp.Domain.Entities;

namespace CleanArchitecture.ToDoApp.UnitTests.Domain
{
    public class TodoItemTests
    {
        [Fact]
        public void CreateTodoItem_WithValidParameters_ShouldCreateItem()
        {
            // Arrange
            string title = "Test Todo Item";
            string description = "This is a test description.";

            // Act
            var todoItem = new TodoItem(title, description);

            // Assert
            Assert.Equal(title, todoItem.Title);
            Assert.Equal(description, todoItem.Description);
            Assert.False(todoItem.IsCompleted);
            Assert.Null(todoItem.CompletedAt);
            Assert.NotEqual(Guid.Empty, todoItem.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateTodoItem_WithInvalidTitle_ShouldThrowException(string invalidTitle)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new TodoItem(invalidTitle, "Description"));
        }

        [Fact]
        public void MarkAsIncomplete_ShouldSetIsCompletedToFalse()
        {
            // Arrange
            var todoItem = new TodoItem("Test", "Description");
            todoItem.MarkAsComplete();

            // Act
            todoItem.MarkAsIncomplete();

            // Assert
            Assert.False(todoItem.IsCompleted);
            Assert.Null(todoItem.CompletedAt);
        }

        [Fact]
        public void UpdateTitle_WithValidTitle_ShouldUpdateTitle()
        {
            // Arrange
            var todoItem = new TodoItem("Test", "Description");
            string newTitle = "Updated Title";

            // Act
            todoItem.UpdateTitle(newTitle);

            // Assert
            Assert.Equal(newTitle, todoItem.Title);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdateTitle_WithInvalidTitle_ShouldThrowException(string invalidTitle)
        {
            // Arrange
            var todoItem = new TodoItem("Test", "Description");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => todoItem.UpdateTitle(invalidTitle));
        }

        [Fact]
        public void UpdateDescription_ShouldUpdateDescription()
        {
            // Arrange
            var todoItem = new TodoItem("Test", "Description");
            string newDescription = "Updated Description";

            // Act
            todoItem.UpdateDescription(newDescription);

            // Assert
            Assert.Equal(newDescription, todoItem.Description);
        }
    }
}
