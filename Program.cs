using Microsoft.Playwright;

var url = "https://www.instagram.com/";
var username = "tiketkeretaupsate";
var password = "Rafli1st!1";

var message = "Join Channel telegram Info tiket kereta murah cepat dan akurat di https://t.me/tiketkeretaupdate";
IReadOnlyList<IElementHandle> comments;

var igTarget = "https://www.instagram.com/kai121_/";

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new()
{
    Headless = false
});
var page = await browser.NewPageAsync(new()
{
    TimezoneId = "Asia/Jakarta",
    Permissions = new[] { "geolocation" },
    Geolocation = new Geolocation() { Longitude = 106.82220924797684F, Latitude = -6.168894415644098F },
    ColorScheme = ColorScheme.Dark,
    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36"
});
await page.GotoAsync(url);

await page.Locator("input[name=\"username\"]").FillAsync(username);
await page.Locator("input[name=\"password\"]").FillAsync(password);
await page.GetByText("Log in").First.ClickAsync();
await page.WaitForNavigationAsync(new() { WaitUntil = WaitUntilState.NetworkIdle });

await page.GotoAsync("https://www.instagram.com/direct/inbox/");
// read log username.txt and parse to list
var usernames = File.ReadAllLines("username.txt").ToList();

foreach (var u in usernames)
{
    await page.GotoAsync("https://www.instagram.com/direct/inbox/");
    await page.Locator("svg[aria-label=\"New message\"]").ClickAsync();
    await page.Locator("input[placeholder=\"Search...\"]").FillAsync(u);
    await page.GetByText(u).Nth(0).ClickAsync();
    await page.ClickAsync("div[role=\"button\"]:text('Chat')");
    await page.Locator("div[aria-label=\"Message\"]").FillAsync(message);
    await page.ClickAsync("div[role='button']:text('Send')");
    await Task.Delay(90000);
}


//await page.GotoAsync(igTarget);
//await page.Locator("img[crossorigin=\"anonymous\"]").Nth(3).ClickAsync();
//await page.Locator("._a9z6._a9za").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
//await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//await Task.Delay(1000);
//await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//await Task.Delay(1000);
//await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");

//HashSet<IElementHandle> komentElementHandle = new();
//var komenElements = await page.QuerySelectorAllAsync("._a9zr");
//komenElements.ToList().ForEach(k => komentElementHandle.Add(k));
//await page.Locator("._abl-").Nth(3).ClickAsync();

//HashSet<string> usernamesA = new();
//HashSet<string> commentsA = new();

//foreach (var komen in komentElementHandle)
//{
//    await readkomen(komen);
//}

//for (var i = 0; i < 999; i++)
//{
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    await page.EvaluateAsync(@"document.querySelector('._a9z6._a9za').scrollBy(0, 1000);");
//    await Task.Delay(1000);
//    try
//    {
//        var elementLocator = page.Locator("._abl-").Nth(3);
//        await elementLocator.ClickAsync();

//        var newKomenElements = await page.QuerySelectorAllAsync("._a9zr");
//        foreach (var komen in newKomenElements.Except(komentElementHandle))
//        {
//            await readkomen(komen);
//        }
//        newKomenElements.ToList().ForEach(k => komentElementHandle.Add(k));
//    }
//    catch
//    {
//        Console.WriteLine("No more comments");
//        break;
//    }
//}

//async Task readkomen(IElementHandle komen)
//{
//    var usernameElement = await komen.WaitForSelectorAsync("a[role=\"link\"]");
//    var usernameText = await usernameElement.InnerTextAsync();
//    // only show in console if usernameText is not in usernamesA
//    if (!usernamesA.Contains(usernameText))
//    {
//        Console.WriteLine($"Username: {usernameText}");
//        // log to txt
//        File.AppendAllText("username.txt", $"{usernameText}\n");

//    }
//    usernamesA.Add(usernameText);

//    // Get the inner text of the comment element
//    var commentElement = await komen.WaitForSelectorAsync("._a9zs");
//    var commentText = await commentElement.InnerTextAsync();
//    // only show in console if commentText is not in commentsA
//    if (!commentsA.Contains(commentText))
//    {
//        Console.WriteLine($"Comment: {commentText}");
//    }
//    commentsA.Add(commentText);

//}
Console.WriteLine("Done");
await Task.Delay(-1);