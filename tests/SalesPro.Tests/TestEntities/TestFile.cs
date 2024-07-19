﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace SalesPro.Tests.TestEntities
{
    public class TestFile : FileCreateDto
    {
        public static string Scope = "test-scope-ui";

        public readonly string FilePath;

        public readonly Stream DataBuffer;

        public TestFile(string fileName, int length)
        {
            var buffer = new byte[length];
            DataBuffer = new MemoryStream(buffer);

            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType);

            File = new FormFile(DataBuffer, 0, DataBuffer.Length, fileName, fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType!,
            };
            FilePath = fileName;
            ScopeUid = Scope;
        }
    }
}