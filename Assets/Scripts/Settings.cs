public class Settings : Singleton<Settings> {
    protected Settings() { } // guarantee this will be always a singleton only - can't use the constructors
    public string myGlobalVar = "whatever";


    public string character = "OrangUtan";

    public string playerOne = "OrantUtan";
    public string playerTwo = "Rhino";

    public int CharacterCode(string characterstring) {
        switch (characterstring) {
            case "OrangUtan":
                return 0;
            case "Rhino":
                return 1;
            case "Como":
                return 2;
        }

        return 0;
    }

    public string CharacterString(int characterCode) {
        switch (characterCode) {
            case 0:
                return "OrantUtan";
            case 1:
                return "Rhino";
            case 2:
                return "Como";
        }

        return "OrangUtan";

    }
}