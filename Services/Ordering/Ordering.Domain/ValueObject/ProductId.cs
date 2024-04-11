﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObject;
public record ProductId
{
    public Guid Value { get;  }
    public ProductId(Guid value) => Value = value;

    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            //throw new DomainException("ProductId can not be empty.");
        }
        return new ProductId(value);
    }
}
