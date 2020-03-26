#include<iostream>
#include<string>

using namespace std;
class Caesar
{
public:
	char message[100], ch;
	int i, celsi;
	void Enkriptimi(char message[100], int celsi);
	void Dekriptimi(char message[100], int celsi);
	

};
void Caesar::Enkriptimi(char message[100],int celsi)
{
	cin.getline(message, 100);
	cout << " ";
	cin >> celsi;


	for (i = 0; message[i] != '\0'; ++i) {
		ch = message[i];

		if (ch >= 'a' && ch <= 'z') {
			ch = ch + celsi;

			if (ch > 'z') {
				ch = ch - 'z' + 'a' - 1;
			}

			message[i] = ch;
		}
		else if (ch >= 'A' && ch <= 'Z') {
			ch = ch + celsi;

			if (ch > 'Z') {
				ch = ch - 'Z' + 'A' - 1;
			}

			message[i] = ch;
		}
	}
	cout << " " << message;
} 
void Caesar::Dekriptimi(char message[100], int celsi)
{
	cin.getline(message, 100);
	cout << " ";
	cin >> celsi;


	for (i = 0; message[i] != '\0'; ++i) {
		ch = message[i];

		if (ch >= 'a' && ch <= 'z') {
			ch = ch - celsi;

			if (ch < 'a') {
				ch = ch + 'z' - 'a' + 1;
			}

			message[i] = ch;
		}
		else if (ch >= 'A' && ch <= 'Z') {
			ch = ch - celsi;

			if (ch > 'a') {
				ch = ch + 'Z' - 'A' + 1;
			}

			message[i] = ch;
		}
	}

	cout << " " << message;
}
