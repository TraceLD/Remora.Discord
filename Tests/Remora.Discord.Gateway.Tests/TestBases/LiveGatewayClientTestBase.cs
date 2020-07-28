//
//  LiveGatewayClientTestBase.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using Microsoft.Extensions.DependencyInjection;
using Remora.Discord.Gateway.Extensions;

namespace Remora.Discord.Gateway.Tests.TestBases
{
    /// <summary>
    /// Acts as a base class for testing the live gateway client.
    /// </summary>
    public class LiveGatewayClientTestBase
    {
        /// <summary>
        /// Gets the gateway client.
        /// </summary>
        protected DiscordGatewayClient GatewayClient { get; }

        /// <summary>
        /// Gets the services.
        /// </summary>
        protected IServiceProvider Services { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveGatewayClientTestBase"/> class.
        /// </summary>
        protected LiveGatewayClientTestBase()
        {
            var token = Environment.GetEnvironmentVariable("REMORA_BOT_TOKEN") ?? string.Empty;

            this.Services = new ServiceCollection()
                .AddDiscordGateway(() => token)
                .BuildServiceProvider();

            this.GatewayClient = this.Services.GetRequiredService<DiscordGatewayClient>();
        }
    }
}