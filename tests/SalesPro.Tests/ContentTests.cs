﻿using SalesPro.Helpers;

namespace SalesPro.Tests;

public class ContentTests : SimpleTableTests<Content, TestContent, ContentUpdateDto, IEntityService<Content>>
{
    public ContentTests()
        : base("/api/content")
    {
    }

    [Fact]
    public async Task GetAllTestAnonymous()
    {
        await GetAllRecords(true);
    }

    [Fact]
    public async Task CreateAndGetItemTestAnonymous()
    {
        await CreateAndGetItem(true);
    }

    [Fact]
    public async Task CheckTags()
    {
        await CreateItem();
        var response = await GetTest(itemsUrl + "/tags", HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        var data = JsonHelper.Deserialize<string[]>(content);
        data.Should().NotBeNull();
        data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CheckCategories()
    {
        await CreateItem();
        var response = await GetTest(itemsUrl + "/categories", HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        var data = JsonHelper.Deserialize<string[]>(content);
        data.Should().NotBeNull();
        data.Should().NotBeEmpty();
    }

    protected override ContentUpdateDto UpdateItem(TestContent to)
    {
        var from = new ContentUpdateDto();
        to.Type = from.Type = to.Type + "Updated";
        return from;
    }
}