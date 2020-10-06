# ClinkedIn

## Description
ClinkedIn was our second group project, helping us incorporate all we had learned about Linq, Collections, and API calls in one assignment. 

## Individual Contributions
My individual contributions included the ability to view an inmate's friends as well as the friends of any one of her current friends, the ability to add and remove a friend, the ability for wardens to create their warden user records and to see all inmates and their data, as well as the ability for each inmate to see her sentence details - start date, end date, and remaining days in the clinker!

## Lessons Learned
I enjoyed learning to use Postman and the ease it brought to demoing our API calls. As a team, we continued to improve our mob programming skills. 

## Project Instructions

You are an intrepid entrepreneur in the niche social network space.  Your latest trillion dollar idea is ClinkedIn, a social network for prisons.  This social network will allow inmates to create inmate accounts with their personal details, including why they're in prison, as well as to socialize and find friends with similar criminal interests.  You'll also be wanting a way to monetize this app, so having a section that allows for the listing of services is your entryway to the real money.  

You'll be building this in teams, and we're only concerned with building the API right now. 

## Example Repository Class

```csharp
class ClinkedInRepository
{
    static List<Clinker> _clinkers = new List<Clinker>();

    public List<Clinker> GetClinkers()
    {
        throw new NotImplementedException();
    }

    public void SaveNewClinker(Clinker newClinker)
    {
        throw new NotImplementedException();
    }
}
```

Your first task as a team will be to break down the following requirements into smaller chunks.  You are welcome to work on some tasks together, but everyone will need to have commits with substance.

# Requirements

As an incarcerated person

I want to join a social network

So that I'm not so lonely

As ClinkedIn member

I want to find other Clinkers by interest

So that I can make friends

As a ClinkedIn member

I want to list my services

So that other inmates can ask me for help

As a ClinkedIn member

I want to keep track of my friends

So that I can know who has my back

As a ClinkedIn member

I want to keep track of my enemies

So that I know who to watch out for

# Stretch Goals

As a ClinkedIn member

I want to know who my friends' friends are

So that I can build up my crew

As a Clinker

I want to update and remove pieces of information, like interests and services

So that as I evolve as a person I can let everyone know

As a Warden

I want to get all inmates information

So that I can peruse the population

As a Clinker 

I want to know how many days remain in my sentence

So that I can keep track
