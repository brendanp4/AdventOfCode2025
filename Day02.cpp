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
		long long val = 0;			
		std::vector<std::pair<long long, long long>> ranges;
		while (std::getline(iFile, input)) {
			val = 0;
			std::pair<long long, long long> range;
			for (auto c : input) {
				if (c == '-') {
					range.first = val;
					val = 0;
				}
				else if (c == ',') {
					range.second = val;
					ranges.push_back(range);
					val = 0;
				}
				else {
					val *= 10;
					val += c - 48;
				}
			}
			range.second = val;
			ranges.push_back(range);
		}

		//Part 1
		//std::vector<int> invalids;
		//long long sum = 0;
		//for (const auto& range : ranges) {
		//	std::cout << range.first << " - " << range.second << "\n";
		//	for (long long i = range.first; i <= range.second; i++) {
		//		std::string num = std::to_string(i);
		//		if (num.size() % 2 == 0 && num.substr(0, num.size() / 2) == num.substr(num.size() / 2, num.size() / 2)) {
		//			std::cout << "\tID: " << i << "\n";
		//			invalids.push_back(i);
		//			sum += static_cast<long long>(i);
		//		}
		//	}
		//	std::cout << "------------------------\nSum: " << sum << "\n------------------------\n";
		//}

		//Local variables
		std::map<long long, int> invalids;
		long long sum = 0;
		for (const auto& range : ranges) {

			//Print the range
			std::cout << range.first << " - " << range.second << "\n";

			//Iterate over all IDs in the range
			for (long long i = range.first; i <= range.second; i++) {

				//Convert the ID to a string
				std::string num = std::to_string(i);

				//Get the length of the ID string
				int len = num.size();

				for (int j = 2; j <= len; j++) {
					if (len % j == 0) {
						int nlen = len / j;
						std::string base = num.substr(0, nlen);
						bool invalid = true;
						for (int k = 1; k < j; k++) {
							if (base != num.substr(nlen * k, nlen)) {
								invalid = false;
								break;
							}
						}
						if (invalid) {
							if (invalids.count(i)) continue;
							invalids[i]++;
							sum += i;
							std::cout << "\tID: " << i << "\n";
						}
					}
				}
			}
			std::cout << "------------------------\nSum: " << sum << "\n------------------------\n";
		}


		std::cout << sum << std::endl;

	}
	return 0;
}
