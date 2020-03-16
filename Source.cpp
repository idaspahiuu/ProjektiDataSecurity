#include<iostream>
#include<string>
using namespace std;
string mesazhi, celesi;
int main()
{
	int zgj;

	cout << "Verejtje!" << endl << "Permbajtja e mesazhit dhe celesit duhet te jene tekstuale." << endl;
	cout << "Shtypni 1 per enkriptim." << endl << "Shtypni 2 per dekriptim" << endl;
	cout << "Zgjedhja: ";
	cin >> zgj;

	switch (zgj)
	{
	case 1:
		cout << "Enkriptimi: ";
		break;
	case 2:
		cout << "Dekriptimi: ";
		break;
	default:
		break;
	}

	return 0;
}