#include <iostream>
#include <string>

using namespace std;
class Vigenere
{
public:
    string mesazhi;
    string celesi;
    int tabela[26][26];

    void caps();
    void krijimiTabeles();
    void enkriptimi(string mesazhi, string celesi);
    int numerimi(int cel, int msg);
    void dekriptimi(string mesazhi, string celesi);
};


//funksioni per kthimin e tekstit dhe celesit ne shkronja te medha si dhe pershatja e celesit me tekstin(per nga madhesia)
void Vigenere::caps() {
    string msg;
    cout << "Shkruani tekstin qe doni te enkriptoni/dekriptoni: ";
    getline(cin, msg);
    cin.ignore();

    for (int i = 0; i < msg.length(); i++) {
        msg[i] = toupper(msg[i]);
    }

    string cel;
    cout << "Shkruani celesin per enkriptim/dekriptim: ";
    getline(cin, cel);
    cin.ignore();


    for (int i = 0; i < cel.length(); i++) {
        cel[i] = toupper(cel[i]);
    }


    string cel1 = "";
    for (int i = 0, j = 0; i < msg.length(); i++) {
        if (msg[i] == 32) {
            cel1 += 32;
        }
        else {
            if (j < cel.length()) {
                cel1 += cel[j];
                j++;
            }
            else {
                j = 0;
                cel1 += cel[j];
                j++;
            }//ifelse(2)
        } //ifelse(1)
    } //unaza for


    mesazhi = msg;
    celesi = cel1;
}


void Vigenere::krijimiTabeles() {
    for (int i = 0; i < 26; i++) {
        for (int j = 0; j < 26; j++) {
            int n;
            if ((i + 65) + j > 90) {
                n = ((i + 65) + j) - 26;

                //ASCII kodi i shkronjes se alfabetit ne poziten e indeksit te tabeles

                tabela[i][j] = n;
            }
            else {
                n = (i + 65) + j;


                tabela[i][j] = n;
            }
        }
    }

}
//Krijimi i funksionit per enkriptim
void Vigenere::enkriptimi(string mesazhi, string celesi) {
    krijimiTabeles();
    string ciphertxt = "";
    for (int i = 0; i < mesazhi.length(); i++) {
        if (mesazhi[i] == 32 && celesi[i] == 32) {
            ciphertxt += " ";
        }
        else {
            int x = (int)mesazhi[i] - 65;
            int y = (int)celesi[i] - 65;
            ciphertxt += (char)tabela[x][y];
        }
    }

    cout << "Teksti i enkriptuar: " << ciphertxt;
}


//fillojme numerimin nga ASCII kodi per shkronjen e celesit dhe mbarojme tek shkronja e fundit e mesazhit
int Vigenere::numerimi(int cel, int msg) {
    int k = 0;
    string rez = "";

    //qe ti perfshjime te gjitha shkronjat e alfabetit(26) kemi:
    for (int i = 0; i < 26; i++) {
        if (cel + i > 90) {
            rez += (char)(cel + (i - 26));
        }
        else {
            rez += (char)(cel + i);
        }
    }

    for (int i = 0; i < rez.length(); i++) {
        if (rez[i] == msg) {
            break;
        }
        else {
            k++;
        }
    }
    return k;
}

//Krijimi i funksionit per dekriptim
void Vigenere::dekriptimi(string mesazhi, string celesi) {
    string plaintxt = "";
    for (int i = 0; i < mesazhi.length(); i++) {
        if (mesazhi[i] == 32 && celesi[i] == 32) {
            plaintxt += " ";
        }
        else {
            int n = numerimi((int)celesi[i], (int)mesazhi[i]);
            plaintxt += (char)(65 + n);
        }
    }

    cout << "Teksti i dekriptuar: " << plaintxt;
}

int main()
{
  

    return 0;
}
