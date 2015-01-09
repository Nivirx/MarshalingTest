#include "stdafx.h"
#include "MarshalMe.h"


///C-Style export with a C-Sytle call (cdecl)
extern "C" void API_EXPORT _cdecl printC(char* msg) {
	printf(msg);
	printf("printed from a _cdecl function\n");
}

///C++ Style export with C++ call (stdcall)
void API_EXPORT _stdcall printS(char* msg) {
	printf(msg);
	printf("printed from a _stdcall function\n");
}

///C++ Style export with C++ call (stdcall)
int API_EXPORT _stdcall addC(int a, int b) {
	int c = a + b;
	printf("%d + %d = %d\n", a, b, c);
	return c;
}
