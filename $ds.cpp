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

class Rail {
public:
    string enkriptimi(string mesazhi, int rreshti)
    {
        int l = mesazhi.length();
        int k = 0, kolona;
        kolona = l / rreshti;


        //krijimi i nje loop if i cili e kontrollon a eshte numri i kolones 
        //numer i plote , nese nuk eshte duhet shtuar nje kolon ekstra
        if (l % rreshti == !0)
        {
            kolona++;
        }


        // matrica s
        char s[rreshti][kolona];
        // futja e shkronjave ne matrice 
        for (int i = 0; i < kolona; i++) {
            for (int j = 0; j < rreshti; j++) {
                s[i][j] = mesazhi[k];
                k++;
            }
        }

        //paraqitja e matrices se formuar
        for (int i = 0; i < rreshti; i++) {
            for (int j = 0; j < kolona; j++) {
                if (s[j][i] == '\0')
                    cout << 'X';        //kur nuk ka shkronja matrica te mbushet me shkronjen 'X'
                cout << s[j][i];    //paraqitja matrices
            }

        }
        cout << endl; //cout eshte per te larguar per nje rresht funksionet
        return"";
    }
    string show1(string mesazhi, int rreshti) {
        //inicializimi i l,k,rreshtit dhe kolones
        int l = mesazhi.length();
        int  kolona;
        int k = 0;
        kolona = l / rreshti;


        //krijimi i nje loop if i cili e kontrollon a eshte numri i kolones 
        //numer i plote , nese nuk eshte duhet shtuar nje kolon ekstra
        if (l % rreshti != 0)
        {
            kolona++;
        }


        // matrica s
        char s[rreshti][kolona];
        // futja e shkronjave ne matrice 
        for (int i = 0; i < kolona; i++) {
            for (int j = 0; j < rreshti; j++) {
                s[i][j] = mesazhi[k];
                k++;
            }
        }

        //paraqitja e matrices se formuar
        for (int i = 0; i < rreshti; i++) {
            for (int j = 0; j < kolona; j++) {
                if (s[j][i] == '\0')
                    cout << 'X';        //kur nuk ka shkronja matrica te mbushet me shkronjen 'X'
                cout << s[j][i];    //paraqitja matrices
            }
            cout << endl; //cout e mundson shfaqjen e tekstit ne shirita
        }
        return"";
    }

    //funksioni per enkriptimin e mesazhit ne formen
    //rail-fence
    string dekriptimi(string mesazhi, int kolona)
    {
        int l = mesazhi.length();
        int k = 0, rreshti;
        // e kemi ba ndrrimin e kolones me rreshtin nkrahasim me kodin per enkriptimin
        rreshti = l / kolona; // per arsye se duhet me u vendos e kunderta per me arrit dekriptimin




        //nkrahasim me enkriptim ktu nuk kemi nevoj per krijimin e if , per aryse se matrica eshte e mbushur


        // matrica s
        char s[rreshti][kolona];
        // futja e shkronjave ne matrice 
        for (int i = 0; i < kolona; i++) {
            for (int j = 0; j < rreshti; j++) {
                s[i][j] = mesazhi[k];
                k++;
            }
        }

        //paraqitja e matrices se formuar
        for (int i = 0; i < rreshti; i++) {
            for (int j = 0; j < kolona; j++) {

                cout << s[j][i];    //paraqitja matrices
            }

        }
        cout << endl;
        return "";
    }
    string show(string mesazhi, int kolona) {
        int l = mesazhi.length();
        int k = 0, rreshti;
        // e kemi ba ndrrimin e kolones me rreshtin nkrahasim me kodin per enkriptimin
        rreshti = l / kolona; // per arsye se duhet me u vendos e kunderta per me arrit dekriptimin




        //nkrahasim me enkriptim ktu nuk kemi nevoj per krijimin e if , per aryse se matrica eshte e mbushur


        // matrica s
        char s[rreshti][kolona];
        // futja e shkronjave ne matrice 
        for (int i = 0; i < kolona; i++) {
            for (int j = 0; j < rreshti; j++) {
                s[i][j] = mesazhi[k];
                k++;
            }
        }

        //paraqitja e matrices se formuar
        for (int i = 0; i < rreshti; i++) {
            for (int j = 0; j < kolona; j++) {

                cout << s[j][i];    //paraqitja matrices
            }
            cout << endl;
        }
        return "";
    }
};

int main(int argc, char* argv[])
{
    Rail r;
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
        if (strcmp(argv[2], "encrypt") == 0) {
            string message = argv[3];
            int key = atoi(argv[4]);
            string encoded = c.encode(message, key);
            cout << encoded << endl;
        }
        else if (strcmp(argv[2], "decrypt") == 0) {
            string message = argv[3];
            int key = atoi(argv[4]);
            string decoded = c.decode(message, key);
            cout << decoded << endl;

        }
    }
    if (strcmp(argv[1], "rail-fence") == 0) {
        if (strcmp(argv[2], "encrypt") == 0) {
            string mesazhi = argv[3];
            int kolona = atoi(argv[4]);
            string encrypt = r.enkriptimi(mesazhi, kolona);
            r.show1(mesazhi, kolona);
            cout << encrypt << endl;

        }
        else if (strcmp(argv[2], "decrypt") == 0) {
            string mesazhi = argv[3];
            int kolona = atoi(argv[4]);
            string decrypt = r.dekriptimi(mesazhi, kolona);
            r.show(mesazhi, kolona);
            cout << decrypt << endl;

        }

    }
}
