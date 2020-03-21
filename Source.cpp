#include<iostream>
#include<string>
using namespace std;
string mesazhi, celesi;
//funksioni per kthimin e tekstit ne shkronja te medha
void caps()
{
	string msg, cel, cel1;

	cout << "\nShkruani tekstin qe doni te enkriptoni: "
		cin >> msg;
	for (int i = 0; i < msg.length(); i++)
	{
		msg[i] = toupper(msg[i]);
	}

	cout << "\nShkruani celesin qe doni te shfrytezoni: ";
	cin >> cel;

	for (int i = 0; i < cel.length(); i++)
	{
		cel[i] = toupper(cel[i]);
	}


	for (int i = 0; j=0; i < msg.length(); i++)
	{
		if (msg[i]==32)
		{
			cel1 = cel1 + 32;
		}
		else {
			if(j<cel.length())
			{
				cel1 = cel1 + cel[j];
				j++;
			}
			else
			{
				j = 0;
				cel1 = cel1 + cel[j];
				j++;

			}//if-else(2)
		}//if-else(1)

	}//unaza for

	cout << msg << "\n" << cel1;
	mesazhi = msg;
	celesi = cel1;
};
int main()
{
	char zgj;

	cout << "Verejtje!" << endl << "Permbajtja e mesazhit dhe celesit duhet te jene tekstuale." << endl;
	cout << "Shtypni 'e' per enkriptim." << endl << "Shtypni 'd' per dekriptim" << endl;
	cout << "Zgjedhja: ";
	cin >> zgj;
	
	if (zgj == 'e')
	{
		cout << "Enkriptimi: " << endl;
		caps();
	}
	else if (zgj == 'd')
	{
		cout << "Dekriptimi: " << endl;
	}
	else
	{
		cout << "\nZgjedhja e padefinuar!";
	}

	return 0;
}