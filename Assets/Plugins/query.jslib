mergeInto(LibraryManager.library, 
{
	BrowserGetLinkHREF : function()
	{
		// https://css-tricks.com/snippets/javascript/get-url-and-url-parts-in-javascript/
		var search = window.location.href;
		var searchLen = lengthBytesUTF8(search) + 1;
		var buffer = _malloc(searchLen);
		stringToUTF8(search, buffer, searchLen);
		return  buffer;
	},
});