#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>

int main()
{

	std::ifstream iFile;
	iFile.open("C:\\Users\\brend\\Documents\\input.txt", std::ios::in);
	if (iFile.fail()) {
		std::cerr << "File not found\n";
	}
	else {
		std::string input;
		int val = 0;			//Number of clicks to turn dial
		int pos = 50;			//Dial position
		int fullRotations = 0;	//Number of times dial is rotated fully = val / 100
		int total = 0;			//Number of times dial is found at position '0'
		while (std::getline(iFile, input)) {
			//std::cout << input;
			//Parse input text
			val = 0;
			for (int i = 1; i < input.size(); i++) {
				val *= 10;
				val += input[i] - 48;
			}

			////Get direction
			//if (input[0] == 'L') val *= -1;

			//brute forced
			for (int i = 0; i < abs(val); i++) {
				input[0] == 'L' ? pos-- : pos++;
				if (pos == 0) total++;
				if (pos == -1) pos = 99;
				if (pos == 100) {
					pos = 0;
					total++;
				}
			}

		//	//Get number of full rotations
		//	fullRotations = abs(val / 100);
		//	total += fullRotations;

		//	//Turn dial
		//	val %= 100;
		//	pos += val;

		//	std::cout << " -> " << pos << std::endl;

		//	//Check if it passes '0'
		//	if (pos == 0) {
		//		total++;
		//		std::cout << "Hit 0!\n";
		//	}
		//	else if (pos > 99) 
		//	{
		//		pos -= 100;
		//		total++;
		//		std::cout << "Passed 0\n";
		//	}
		//	else if (pos < 0) 
		//	{
		//		pos += 100;
		//		total++;
		//		std::cout << "Passed 0\n";
		//	}

		//	std::cout << "\tFull rotations: " << fullRotations << std::endl;
		//	std::cout << "\tTotal: " << total << std::endl << std::endl;
		}
		std::cout << total << std::endl;

	}
	return 0;
}
