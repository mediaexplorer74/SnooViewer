using System;

namespace SnooViewer.Api.Models
{
    public interface ICreated
    {
        DateTime Created { get; }

        DateTime CreatedUtc { get; }
    }
}
