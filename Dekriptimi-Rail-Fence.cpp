#include <iostream> 
using namespace std; 
  
//funksioni per enkriptimin e mesazhit ne formen
//rail-fence
void dekriptimi(string mesazhi) 
{
     int l = mesazhi.length(); 
    int k = 0, rreshti, kolona;
    kolona=3; // e kemi ba ndrrimin e kolones me rreshtin nkrahasim me kodin per enkriptimin
    rreshti = l/kolona; // per arsye se duhet me u vendos e kunderta per me arrit dekriptimin
    
     
    

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
    cout<<endl;
} 
void show(string mesazhi){
  int l = mesazhi.length(); 
    int k = 0, rreshti, kolona;
    kolona=3; // e kemi ba ndrrimin e kolones me rreshtin nkrahasim me kodin per enkriptimin
    rreshti = l/kolona; // per arsye se duhet me u vendos e kunderta per me arrit dekriptimin
    
     
    

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
         cout<<endl;
    } 
}
// int main i krijuar sa per test a po punon funksioni ne rregull
int main() 
{ 
    string mesazhi = "tomerahiswkenew"; //mesazhi i futur ne string
    dekriptimi(mesazhi); //thirrja e funksionit dekriptimi
    show(mesazhi);//thirrja e funksionit show
    return 0; 
}
