namespace Se7en.Network {

    public sealed class UserAgent {
        //TODO - --
        private string[] BasicBrowser = new string[]
        {
            "Mozilla/5.0"
        };

        private string[] Platform = new string[]{
            "Macintosh", "Windows NT", "X11", "Android", "Linux", "iPhone", "TV", "Mobile", "Tablet",
        };

        private static readonly string[] s_agents =
        {
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X x.y; rv:42.0) Gecko/20100101 Firefox/42.0",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36"
        };

        private readonly string _agent;
        private UserAgent(string agent)
        {
            _agent = agent;
        }

        public static UserAgent CreateRandom() => new UserAgent(s_agents[Utils.Random.Next(s_agents.Length)]);
    }
}