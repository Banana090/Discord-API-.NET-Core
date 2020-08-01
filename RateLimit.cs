using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordAPI.Helpers;

namespace DiscordAPI
{
    internal class RateLimit
    {
        internal int maxRequests;
        internal int leftRequests;

        private bool resetRunning;
        private bool setupProper;
        private RESTRequester requester;

        internal RateLimit(RESTRequester requester, int max, int left, bool properInfo = false)
        {
            this.requester = requester;
            maxRequests = max;
            leftRequests = left;

            resetRunning = false;
            setupProper = properInfo;
        }

        internal void SetupLimits(int max, int left)
        {
            if (!setupProper)
            {
                maxRequests = max;
                leftRequests = left;
                setupProper = true;
            }
        }

        internal void ResetAfter(int ms)
        {
            if (!resetRunning)
            {
                resetRunning = true;
                Reset(ms);
            }
        }

        private async void Reset(int ms)
        {
            await Task.Delay(ms);
            leftRequests = maxRequests;
            requester.UpdateQueue();
            resetRunning = false;
        }

        internal bool GetRequest()
        {
            if (leftRequests > 0)
            {
                leftRequests--;
                return true;
            }

            return false;
        }
    }
}
