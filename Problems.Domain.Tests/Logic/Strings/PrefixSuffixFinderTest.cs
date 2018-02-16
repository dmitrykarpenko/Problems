using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Domain.Logic.Strings.PrefixSuffixFinder;
using GU = Problems.Domain.Tests.Utils.GenericUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Logic.Strings
{
    [TestClass]
    public class PrefixSuffixFinderTest
    {
        [TestMethod]
        public void WordFilterFTest()
        {
            // Arrange:
            var inputObjects = new[]
            {
                new
                {
                    Words = new[] { "cabbage", "apple", "carrot" },
                    Searches = new[]
                    {
                        new { Prefix = "a", Suffix = "e", Output = 1, },
                        new { Prefix = "ca", Suffix = "e", Output = 0, },
                        new { Prefix = "cab", Suffix = "", Output = 0, },
                        new { Prefix = "", Suffix = "", Output = 2, },
                        new { Prefix = "", Suffix = "ge", Output = 0, },
                        new { Prefix = "", Suffix = "e", Output = 1, },
                        new { Prefix = "", Suffix = "carrot", Output = 2, },
                    },
                    Repeat = 1,
                },
                new
                {
                    Words = new string[] { },
                    Searches = new[]
                    {
                        new { Prefix = "a", Suffix = "b", Output = -1, },
                        new { Prefix = "", Suffix = "", Output = -1, },
                        new { Prefix = (string)null, Suffix = (string)null, Output = -1, },
                    },
                    Repeat = 1,
                },
                new
                {
                    Words = new[] { "smoggy", "import", "arsenic", "television", "grass", "confused", "author", "auditor", "worse", "clang", "sarcastic", "granola", "chest", "fields", "flavoured", "it", "giraffe", "afterdeck", "rothwell", "cat", "lackluster", "bearded", "banker", "livermorium", "house", "wheelchair", "chocolaty", "desktop", "ordinal", "gecko", "flash", "bad", "funds", "careers", "tow", "delayed", "yeoman", "wisp", "neuter", "luff", "stopper", "conditions", "neutron", "leopard", "camber", "nano", "flare", "acclaimed", "rye", "bandage", "relish", "strict", "ionic", "postit", "scoop", "work", "island", "crab", "glean", "chicken", "slipway", "ranked", "juicy", "sweet", "bricklayer", "brent", "mitral", "converse", "underage", "mocking", "sine", "disloyal", "sericite", "herbs", "countless", "seagull", "strength", "integers", "cuillin", "stench", "dingleberry", "diagnostic", "syntaxis", "beeping", "angular", "astatine", "redstart", "changing", "wizards", "footer", "unicorn", "prune", "eof", "excitable", "triangle", "nestle", "stars", "mitt", "heinz", "melba", "parka", "mailbox", "obsidian", "chops", "howl", "tactless", "worth", "batter", "bullocks", "hotel", "handling", "halftime", "dear", "notable", "certificate", "foolhardy", "strontium", "gorilla", "launching", "vole", "metric", "example", "system", "pointers", "gratis", "solitary", "ratio", "lord", "starboard", "hack", "rebuff", "brewer", "quirky", "boules", "porsche", "niggles", "drug", "gaia", "quarterly", "tickle", "compressed", "gale", "dozens", "avocado", "impatient", "abdomen", "customs", "children", "rotation", "soupy", "steer", "gain", "hourglass", "originates", "picket", "sheep", "capricious", "wifi", "language", "adapter", "fels", "announce", "nicknames", "afraid", "volta", "wealth", "boron", "fortunate", "volcano", "obsessed", "refresh", "walty", "bumped", "endless", "pudding", "uncertain", "fraiche", "ducks", "reverse", "strained", "cakes", "refer", "hinny", "pacific", "natural", "anthropic", "confess", "american", "grit", "yield", "over", "pantheon", "ship", "garganey", "influence", "scripts", "sugary", "isomer", "ambulance", "tuck", "moons", "sidlaws", "sunhat", "alkene", "sowse", "taylor", "plants", "copper", "seal", "sorbet", "prominence", "hotsprings", "painter", "dripping", "violent", "celebrate", "registered", "mods", "obnoxious", "molecule", "piglet", "samarium", "smartie", "knobby", "enzyme", "ethereal", "sneeze", "forehead", "brisk", "anthology", "surd", "shimmering", "light", "limp", "dispensers", "folder", "bandit", "writhing", "lament", "synonymous", "edge", "impolite", "font", "necktie", "command", "generic", "comis", "glycemic", "documents", "bouncy", "mille", "egyptian", "tender", "kidney", "nightjar", "axel", "planca", "august", "thy", "dunking", "wimp", "different", "forehead", "zester", "date", "know", "grater", "rods", "details", "listen", "gate", "ennui", "dunite", "tremolo", "wheelchair", "tubes", "leukemia", "salient", "stack", "rosin", "trophy", "peeved", "dig", "rofl", "seamstress", "fawr", "street", "ok", "pike", "others", "snarling", "petulant", "scoreboard", "goatish", "twiddling", "dunlin", "moderato", "tonic", "cheery", "doting", "apnea", "vimeo", "bank", "bashful", "ecliptic", "cajole", "wheelhouse", "lush", "excitable", "treasure", "find", "status", "shoreditch", "ultraviolet", "abs", "medical", "hand", "band", "boreal", "chine", "woof", "transfer", "rearing", "london", "trello", "headphones", "keep", "carpaccio", "crake", "footer", "volans", "shirt", "closing", "timenoguy", "stoppers", "atrial", "wealthy", "spud", "curling", "ratty", "china", "hawk", "loutish", "poop", "crowhop", "random", "dancers", "honest", "tor", "operate", "venomous", "guard", "tidy", "orchestra", "bellied", "oakum", "zoom", "fool", "subtype", "battered", "kiwi", "artist", "abstract", "moustache", "steamer", "blizzard", "hence", "parka", "flerovium", "exemplary", "terminal", "macaw", "afocal", "hoovered", "carefree", "asteroids", "paddleball", "skin", "quaint", "mummy", "habitat", "molecule", "sucked", "nosy", "kiss", "architect", "cart", "adept", "motley", "raisins", "snooze", "elongation", "upsilon", "scalp", "tooling", "namaka", "esker", "smacked", "matlab", "weapons", "sloppy", "anvil", "encode", "seed", "camber", "couplekiss", "flux", "reflux", "dartboard", "threaten", "be", "distant", "sunflower", "omicron", "gentrify", "fray", "microphone", "dioxide", "siege", "matrix", "aldus", "seal", "codes", "hopeful", "swiss", "bee", "fax", "coffin", "key", "bee", "deafening", "walnut", "reliable", "kids", "chlorite", "glycemic", "hoary", "building", "pasta", "decline", "opposition", "senior", "yummy", "ununpentium", "sea", "neigh", "plain", "sternway", "ears", "fall", "morals", "museum", "arabian", "expandcost", "table", "underage", "witted", "dressed", "occur", "bicycle", "barnacle", "breathe", "valve", "granita", "fragile", "baud", "security", "leopard", "received", "bomb", "knowing", "apricot", "squeaky", "for", "banner", "tachometer", "resolute", "pitiful", "crystals", "ringed", "alarming", "paypal", "selector", "intent", "ammeter", "kings", "mowing", "mussel", "berwyn", "scholarly", "timid", "cackle", "tie", "insidious", "twee", "beggarly", "minister", "libra", "barrage" },
                    Searches = new[]
                    {
                        new { Prefix = "fi", Suffix = "ields", Output = 13, },
                        new { Prefix = "s", Suffix = "y", Output = 489, },
                        new { Prefix = "on", Suffix = "ed", Output = -1, },
                        new { Prefix = "it", Suffix = "it", Output = 15, },
                        new { Prefix = "tie", Suffix = "tied", Output = -1, },
                        new { Prefix = "timid", Suffix = "", Output = 490, },
                        new { Prefix = "timid", Suffix = "timid", Output = 490, },
                        new { Prefix = "", Suffix = "timid", Output = 490, },
                    },
                    Repeat = 1,
                },
                new
                {
                    Words = GU.CreateArray(new[] { ("a", 10000), ("b", 10000) }),
                    Searches = new[]
                    {
                        new { Prefix = "a", Suffix = "a", Output = 9999, },
                        new { Prefix = "a", Suffix = "", Output = 9999, },
                        new { Prefix = "b", Suffix = "b", Output = 19999, },
                        new { Prefix = "", Suffix = "b", Output = 19999, },
                    },
                    Repeat = 1,
                },
                new
                {
                    Words = GU.CreateArray(new[] { ("f", 10000) }),
                    Searches = new[]
                    {
                        new { Prefix = "a", Suffix = "a", Output = -1, },
                        new { Prefix = "a", Suffix = "", Output = -1, },
                        new { Prefix = "f", Suffix = "f", Output = 9999, },
                    },
                    Repeat = 100,
                },
            };

            foreach (var inputObject in inputObjects)
            {
                IPrefixSuffixFinder prefixSuffixFinder = new WordFilter(inputObject.Words);

                foreach (var search in inputObject.Searches)
                {
                    for (int i = 0; i < inputObject.Repeat; ++i)
                    {
                        // Act:
                        var output = prefixSuffixFinder.F(search.Prefix, search.Suffix);

                        // Assert:
                        Assert.AreEqual(search.Output, output);
                    }
                }
            }
        }
    }
}
