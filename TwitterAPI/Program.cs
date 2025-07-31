// See https://aka.ms/new-console-template for more information

using TwitterAPI;

var token = TwitterAuth.GetToken();

TwitterApiClient twitterAPI = new TwitterApiClient();

Console.Write("What do you want get from Twitter: Search or Username? :");
var type=Console.ReadLine();


var counter = 0;
while( counter < 4)
{
    counter++;
    Console.Write("Input text that you want to search: ");
    var input =Console.ReadLine();
    var data = "";
    if (type.Equals("search", StringComparison.OrdinalIgnoreCase))
        data = twitterAPI.SearchPost(token.AccessToken, input);
    else
        data = twitterAPI.SearchUsername(token.AccessToken, input);

    Console.WriteLine(data);
    Console.WriteLine();
}


Console.WriteLine("Done");
