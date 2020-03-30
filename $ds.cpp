#include <iostream>   //console io
#include <string>     //string handling

using namespace std;

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

class Vigenere
{
public:
    string key;

    Vigenere(string key)
    {
        for (int i = 0; i < key.size(); ++i)
        {
            if (key[i] >= 'A' && key[i] <= 'Z')
                this->key += key[i];
            else if (key[i] >= 'a' && key[i] <= 'z')
                this->key += key[i] + 'A' - 'a';
        }
    }

    string encrypt(string text)
    {
        string out;

        for (int i = 0, j = 0; i < text.length(); ++i)
        {
            char c = text[i];

            if (c >= 'a' && c <= 'z')
                c += 'A' - 'a';
            else if (c < 'A' || c > 'Z')
                continue;

            out += (c + key[j] - 2 * 'A') % 26 + 'A';
            j = (j + 1) % key.length();
        }

        return out;
    }

    string decrypt(string text)
    {
        string out;

        for (int i = 0, j = 0; i < text.length(); ++i)
        {
            char c = text[i];

            if (c >= 'a' && c <= 'z')
                c += 'A' - 'a';
            else if (c < 'A' || c > 'Z')
                continue;

            out += (c - key[j] + 26) % 26 + 'A';
            j = (j + 1) % key.length();
        }

        return out;
    }
};

int main(int argc, char* argv[])
{
    Caesar c;
    string key = argv[3];
    Vigenere cipher(key);

    if (strcmp(argv[1], "vigenere") == 0) {
        if (strcmp(argv[2], "encrypt") == 0) {
            string original = argv[4];
            string encrypted = cipher.encrypt(original);
            cout << encrypted << endl;
        }
        else if (strcmp(argv[2], "decrypt") == 0) {
            string original = argv[4];
            string decrypted = cipher.decrypt(original);
            cout << decrypted << endl;
        }
    }
    if (strcmp(argv[1], "caesar") == 0) {
        if (strcmp(argv[2], "encode") == 0) {
            string message = argv[3];
            int key = atoi(argv[4]);
            string encoded = c.encode(message, key);
            cout << encoded << endl;
        }
        else if (strcmp(argv[2], "decode") == 0) {
            string message = argv[3];
            int key = atoi(argv[4]);
            string decoded = c.decode(message, key);
            cout << decoded << endl;

        }
    }
}