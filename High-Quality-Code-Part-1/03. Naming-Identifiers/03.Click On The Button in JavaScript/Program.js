function clickOnTheButton(event, arguments)
{
    var myWindow = window,
        browser = myWindow.navigator.appCodeName,
        ism;
    if (browser == "Mozilla")
    {
        ism = browser
    };
    if (ism)
    {
        alert("Yes");
    }
    else
    {
        alert("No");
    }
}