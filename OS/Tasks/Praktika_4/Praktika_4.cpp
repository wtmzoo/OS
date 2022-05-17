#include <ctime>
#include <iostream>

int main()
{
    int a = 0, b = 3, c = 3;

    unsigned int start_time = clock();

    for (int i = 0; i < 100000000; i++)
    {
        a += b * 2 + c - i;
    }
    unsigned int end_time = clock();
    unsigned int search_time = end_time - start_time;
    
    std::cout << a << "\n" << search_time << " ms";

}