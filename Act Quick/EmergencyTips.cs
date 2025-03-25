namespace Act_Quick;
public class EmergencyTips
{
    private static readonly Dictionary<string, Item> items = new()
            {
                ["Active Shooter"] = new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Active Shooter",
                    Facts =
                    [
                        "Know where the exits are",
                        "Make a clear announcement as an alert",
                        "Evacuate if possible or barricade all entry points",
                        "Communicate real-time information on shooter location",
                        "(Last resort) Distract the shooter's ability to aim"
                    ]
},
                ["Earthquake"] = new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Earthquake",
                    Facts =
                    [
                        "Drop wherever you are on to your hands and knees",
                        "Cover your head and neck with your arms",
                        "If you are under a table or desk, hold on to it",
                        "Pull over if you are in a vehicle and stop",
                        "Stay away from buildings if you are outside",
                        "Expect aftershocks to follow the main shock"
                    ]
                },
                ["Flood"] = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Flood",
                    Facts =
                    [
                        "Move to higher ground or a higher floor",
                        "Do not walk, swim, or drive through flood waters",
                        "Listen for emergency information and alerts",
                        "Only go on the roof if necessary",
                        "Keep important documents in a waterproof container",
                        "Evacuate if told to do so",
                        "There is risk of electrocution"
                    ]
                },
                ["House Fire"] = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "House Fire",
                    Facts =
                    [
                        "Have two ways to get out from each room",
                        "If a door or doorknob is hot, use a different exit",
                        "Do not use an exit where smoke is coming out",
                        "If your clothes catch fire, stop, drop, and roll",
                        "If trapped, call 9-1-1",
                        "Replace smoke alarm batteries twice a year (except for 10-year lithium batteries)"
                    ]
                },
                ["Hurricane"] = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Hurricane",
                    Facts =
                    [
                        "Gather needed supplies for at least three days",
                        "Stay in a designated storm shelter, or an interior room",
                        "Listen for emergency information and alerts",
                        "Use generators outdoors and away from windows",
                        "Evacuate if told to do so",
                        "Do not walk, swim, or drive through flood waters",
                        "There is risk of electrocution"
                    ]
                },
                ["Pandemic"] = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Pandemic",
                    Facts =
                    [
                        "Stay at least six feet away from other people",
                        "Wear a mask",
                        "Wash hands frequently for at least 20 seconds",
                        "Avoid touching face or other people",
                        "Get the COVID-19 vaccines and boosters"
                    ]
                },
                ["Snowstorm"] = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Snowstorm",
                    Facts =
                    [
                        "Stay indoors",
                        "Be prepared to lose power",
                        "Dress warmly",
                        "Keep body temperature above 95\u2109 (35\u2103)",
                        "Treat frostbite by soaking frostbitten area in warm water",
                        "Treat hypothermia by getting warm (warm room and clothes) and keeping dry",
                        "Older adults, young children, and sick persons are at greater risk"
                    ]
                },
                ["Tornado"] = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Tornado",
                    Facts =
                    [
                        "Get to a sturdy building",
                        "Go to a safe room, basement, or storm cellar",
                        "Stay away from windows, doors, and outside walls",
                        "If you are in a vehicle, do not try to outrun the tornado",
                        "Shield your head and neck with furniture and blankets",
                        "Watch out for flying debris",
                        "Stay clear of fallen power lines or broken utility lines"
                    ]
                },
                ["Wildfire"] = new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Wildfire",
                    Facts =
                    [
                        "Leave if told to do so",
                        "Listen to authorities for when it is safe to return",
                        "If trapped, call 9-1-1",
                        "Listen for emergency information and alerts",
                        "Create a fire-resistant zone for at least 30 feet",
                        "Avoid hot ash, charred trees, smoldering debris, and live embers",
                        "Document property damage with photographs"
                    ]
                }
            };
    private static readonly string[] emergencyKitItems = [
                "Water",
                "Food",
                "Flashlight",
                "Batteries",
                "Phone"
                ];
    public static string[] GetEmergencies() => [.. items.Keys];
    public static string[] GetFacts(string emergency)
    {
        if (string.IsNullOrWhiteSpace(emergency))
        {
            return ["Emergency type is not specified."];
        }

        if (items.TryGetValue(emergency, out Item? value))
        {
            return value.Facts;
        }

        return [$"Unable to load facts for {emergency}."];
    }
    public static string[] GetEmergencyKitItems() => emergencyKitItems;
    public static ContentPage GetPage(string page)
    {
        return page switch
        {
            "Home" => new MainPage(),
            "Emergencies List" => new ButtonListPage { Page = page },
            _ => new FactListPage { Page = page }
        };
    }
}