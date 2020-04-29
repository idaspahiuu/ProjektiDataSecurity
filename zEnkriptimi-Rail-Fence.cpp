#include <iostream> 
using namespace std; 
  
//funksioni per enkriptimin e mesazhit ne formen
//rail-fence
void enkriptimi(string mesazhi) 
{ 
    int l = mesazhi.length(); 
    int k = 0, rreshti, kolona;
    rreshti = 3; 
    kolona = l/rreshti; 
    

    //krijimi i nje loop if i cili e kontrollon a eshte numri i kolones 
    //numer i plote , nese nuk eshte duhet shtuar nje kolon ekstra
    if(l%rreshti==!0)
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
                cout<<'X';        //kur nuk ka shkronja matrica te mbushet me shkronjen 'X'
            cout << s[j][i];    //paraqitja matrices
        } 
         
    } 
    cout<<endl; //cout eshte per te larguar per nje rresht funksionet
} 
void show(string mesazhi){
    //inicializimi i l,k,rreshtit dhe kolones
    int l = mesazhi.length();
    int  rreshti, kolona;
    int k = 0;
    rreshti = 3;
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
    cout<<endl; //cout e mundson shfaqjen e tekstit ne shirita
    }
}
  
// int main i krijuar sa per test a po punon funksioni ne rregull
int main() 
{ 
    string mesazhi = "takohemineser"; //mesazhi i futur ne string
    enkriptimi(mesazhi); //thirrja e funksionit enkriptimi
      show(mesazhi);//thirrja e funksionit show
    return 0; 
}
