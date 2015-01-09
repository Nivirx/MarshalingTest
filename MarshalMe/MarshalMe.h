#define API_EXPORT __declspec(dllexport)


extern "C" {
	void API_EXPORT _cdecl printC(char* msg);
}

void API_EXPORT _stdcall printS(char* msg);
int  API_EXPORT _stdcall addC(int a, int b);
