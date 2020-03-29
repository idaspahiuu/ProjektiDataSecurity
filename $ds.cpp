#include <iostream>   
#include <string>     
using namespace std;
//implementimi i klases Vigenere
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

    string encrypt(string text)//funksioni per enkriptim
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

    string decrypt(string text)//funksioni per dekriptim
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
    //thirrja permes argumenteve
    string key = argv[2];
    Vigenere cipher(key);

    if (strcmp(argv[1], "encrypt") == 0) {
        string original = argv[3];
        string encrypted = cipher.encrypt(original);
        cout << "Encrypted: " << encrypted << endl;
    }

    else if (strcmp(argv[1], "decrypt") == 0) {
        string original = argv[2];
        string decrypted = cipher.decrypt(original);
        cout << "Decrypted: " << decrypted << endl;
    }
}