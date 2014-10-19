#include <stdlib.h> 
int declspec(dllexport) AbsMax(int a, int b)
{ 
	return abs(a) < abs(b) ? abs(b) : abs(a); 
} 