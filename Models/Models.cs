using System;
using System.Collections.Generic;

public class Channel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

public class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Channel_id { get; set; }  // Foreign key
    public string Url { get; set; }
    public string Thumbnail { get; set; }
    public string Wallpaper { get; set; }
    public string Logo { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();  // Many-to-many relationship

    public override string ToString()
    {
        return Title;
    }

    public string GetClassName()
    {
        return this.GetType().Name;
    }
}

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

public class Show
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Thumbnail { get; set; }
    public string Wallpaper { get; set; }
    public string Logo { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();  // Many-to-many relationship
    public string Description { get; set; }
    public int Rating { get; set; }

    public override string ToString()
    {
        return Title;
    }

    public string GetClassName()
    {
        return this.GetType().Name;
    }
}

public class Episode
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Show_id { get; set; }  // Foreign key
    public int Season { get; set; }
    public string Url { get; set; }
    public string Thumbnail { get; set; }

    public override string ToString()
    {
        return Title;
    }
}
