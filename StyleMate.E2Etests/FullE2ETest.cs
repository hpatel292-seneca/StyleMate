using Microsoft.Playwright;

namespace StyleMate.E2Etests
{
    [TestClass]
    public class FullE2ETest : PageTest
    {
        [TestMethod]
        public async Task FullTest()
        {
            await Page.GotoAsync("https://stylemate-staging.azurewebsites.net/");
            await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
            await Page.GetByPlaceholder("name@example.com").ClickAsync();
            await Page.GetByPlaceholder("name@example.com").FillAsync("h1234@gmail.com");
            await Page.GetByPlaceholder("password").ClickAsync();
            await Page.GetByPlaceholder("password").FillAsync("Harshil1234!");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
            await Page.GetByText("Hello, h1234@gmail.com").ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            await Expect(Page.GetByText("Hello, h1234@gmail.com")).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Add New Item" }).ClickAsync();
            await Page.GetByLabel("Name").ClickAsync();
            await Page.GetByLabel("Name").FillAsync("Black T-shirt");
            await Page.GetByLabel("Color").ClickAsync();
            await Page.GetByLabel("Color").FillAsync("Black");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.Cell, new() { Name = "Black T-shirt" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Cell, new() { Name = "Top" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Cell, new() { Name = "Black", Exact = true })).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Edit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Edit Clothing Item" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Main).Locator("div").Filter(new() { HasText = "Name" })).ToBeVisibleAsync();
            await Page.GetByLabel("Name").ClickAsync();
            await Page.GetByLabel("Name").FillAsync("Black T-shirt New");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.Cell, new() { Name = "Black T-shirt New" })).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Details" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Clothing Item Details" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Black T-shirt New" })).ToBeVisibleAsync();
            await Expect(Page.GetByText("Top")).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Back to List" }).ClickAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Find Matches" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Find Matches for Black T-" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Matching Items:" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Response from AI" })).ToBeVisibleAsync();
            await Page.GotoAsync("https://stylemate-staging.azurewebsites.net/");
            await Page.GetByRole(AriaRole.Link, new() { Name = "Delete" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Delete Clothing Item" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Black T-shirt New" })).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Delete" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Logout" })).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
            await Expect(Page.Locator("form")).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Click here to Logout" }).ClickAsync();
            await Expect(Page.GetByText("You have successfully logged")).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Login" })).ToBeVisibleAsync();
        }
    }
}
