class Caesar {
public:
    string encode(string message, int key) {
        for (int i = 0; i < message.length(); i++)

        {
            if (isalpha(message[i]))
            {
                if (isupper(message[i]))
                {
                    char c = message[i];
                    cout << (char)((c - 'A' + key) % 26 + 'A');
                }

                if (islower(message[i]))
                {
                    char c = message[i];
                    cout << char((c - 'a' + key) % 26 + 'a');
                }
            }

            else
            {
                cout << message[i];
            }

        }
        return "";

    }
    string decode(string message, int key) {

        for (int i = 0; i < message.length(); i++)

        {
            if (isalpha(message[i]))
            {
                if (isupper(message[i]))
                {
                    char c = message[i];
                    cout << (char)((c - 'A' - key) % 26 + 'A');
                }

                if (islower(message[i]))
                {
                    char c = message[i];
                    cout << char((c - 'a' - key) % 26 + 'a');
                }
            }

            else
            {
                cout << message[i];
            }
        }

        return "";
    }
};