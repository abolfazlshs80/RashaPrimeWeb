﻿namespace RashaPrimeWeb.Application.Common.Interfaces;

public interface ISmsAdapter
{
    Task<Result> SendAsync(string receiver, string text);
}
