#include<iostream>

using namespace std;

int main()
{
	char message[100], ch;
	int i, celsi;

	cout << "Jepni mesazhin per dekriptim: ";
	cin.getline(message, 100);
	cout << "Jepni celsin: ";
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

	cout << "Mesazhi i Dekriptuar: " << message;

	return 0;
}