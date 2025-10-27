using AwesomeAssertions;
using GitCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace GitCore.UnitTests;

using FilePath = IReadOnlyList<string>;

public class ParsePackFileTests
{
    [Fact]
    public void Parse_pack_files_2025_10_27()
    {
        var filesFromClone = LoadTestDataFiles_2025_10_27();

        filesFromClone.Should().ContainKey(["objects", "pack", "pack-f0af0a07967292ae02df043ff4169bee06f6c143.pack"]);

        throw new NotImplementedException("Implement pack file parsing and verification of its contents.");
    }

    private static IReadOnlyDictionary<FilePath, ReadOnlyMemory<byte>> LoadTestDataFiles_2025_10_27()
    {
        var testDataDir =
            Path.Combine(
                AppContext.BaseDirectory,
                "TestData",
                "2025-10-27-clone",
                "files-after-git-clone");

        Directory.Exists(testDataDir).Should().BeTrue($"Missing test data at: {testDataDir}");

        var result =
            new Dictionary<FilePath, ReadOnlyMemory<byte>>(
                comparer: EnumerableExtensions.EqualityComparer<FilePath>());

        foreach (var file in Directory.EnumerateFiles(testDataDir, "*", SearchOption.AllDirectories))
        {
            var relativePath = Path.GetRelativePath(testDataDir, file);

            var pathParts = relativePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var bytes = File.ReadAllBytes(file);

            result.Add(pathParts, bytes);
        }

        return result;
    }
}
