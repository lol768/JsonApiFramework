﻿// Copyright (c) 2015–Present Scott McDonald. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonApiFramework.JsonApi.Dom.Internal
{
    internal class DomJsonApiVersion : DomObject
        , IDomJsonApiVersion
    {
        // PUBLIC CONSTRUCTORS //////////////////////////////////////////////
        #region Constructors
        public DomJsonApiVersion(params DomProperty[] domProperties)
            : this(domProperties.AsEnumerable())
        { }

        public DomJsonApiVersion(IEnumerable<DomProperty> domProperties)
            : base("jsonapi version object", domProperties)
        {
            foreach (var domProperty in this.DomProperties())
            {
                var apiPropertyType = domProperty.ApiPropertyType;
                switch (apiPropertyType)
                {
                    case PropertyType.Version:
                        this.DomVersion = domProperty;
                        break;

                    case PropertyType.Meta:
                        this.DomMeta = domProperty;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        #endregion

        // PUBLIC PROPERTIES ////////////////////////////////////////////////
        #region IDomJsonApiVersion Implementation
        public IDomProperty DomVersion { get; }

        public IDomProperty DomMeta { get; }
        #endregion
    }
}
