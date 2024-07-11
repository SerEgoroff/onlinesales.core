﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSales.Migrations
{
    /// <inheritdoc />
    public partial class TagsAndCatsToArray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "categories",
                table: "content",
                newName: "category");
            migrationBuilder.AddColumn<string[]>(
                name: "tags_temp",
                table: "content",
                type: "text[]",
                nullable: true);
            migrationBuilder.Sql(@"
					CREATE OR REPLACE FUNCTION pg_temp.array_trim(text[])
                    RETURNS text[]
                    AS
                    $$
                    DECLARE
                       text ALIAS FOR $1;
                       tag text;
                       retVal text[]  := ARRAY[]::TEXT[];
                    BEGIN
                       FOREACH tag IN ARRAY text LOOP
                           retVal = array_append(retVal, trim(tag));
                       END LOOP;
                    RETURN retVal;
                    END;
                    $$
                    LANGUAGE plpgsql 
                       STABLE;
					UPDATE content
					SET tags_temp = subquery.tags
                    FROM (SELECT id, pg_temp.array_trim(string_to_array(tags, ';')) as tags FROM content) AS subquery
					WHERE content.id = subquery.id
            ");
            migrationBuilder.DropColumn("tags", "content");
            migrationBuilder.RenameColumn("tags_temp", "content", "tags");
        }

#pragma warning disable
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
#pragma warning

    }
}
