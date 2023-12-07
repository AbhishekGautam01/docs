# Liskov Substitution Principle Example 
* created by Barbara Liskov

## Scenario
* Streaming Service Platform with two types of uses: Premium and Standard. Both have things in common so we can have parent class for each account type. 
```
public class baseSubscriber{
    public string FullName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}

    public virtual void GiveAccessToFamilyMembers(){
        CW("Access Granted");
    }

    public virtual void AccessToLimitedTitles(){
        CW("Access to limited titles");
    }

    public virtual void AccessToUnlimitedTitles(){
        CW("Access to unlimited titles");
    }
}
```

* we want to make sure the standard user doesn't have same privilege as premium user.

```
public class StandardSubscriber : BaseSubscriber{
    public override void AccessToLimitedTitles(){
        base.AccessToLimitedTitles();
    }

    public override void AccessToUnlimitedTitles(){
        throw new InvalidOperationException("Method not allowed");
    }

    public override void GiveAccessToFamilyMembers(){
        throw new InvalidOperationException("Method not allowed");
    }
}

public class PremiumSubscriber : BaseSubscriber{
    public override void AccessToLimitedTitles(){
        base.AccessToLimitedTitles();
    }

    public override void AccessToUnlimitedTitles(){
        base.AccessToUnlimitedTitles();
    }

    public override void GiveAccessToFamilyMembers(){
        base.GiveAccessToFamilyMembers();
    }
}

```

> **note**  if a child class (premium class for instance) cannot replace the parent class perfectly and vice-versa, it is a strong indication that something needs to reviewed in the model.

## Two Approaches 
1. Specify in the parent class only the common properties and methods, leaving any specialization to the child classes. 
2. Segregate the parent class in multiple interfaces that will be implemented by the underlying proper child classes. 

### OPTION 1
```
public class baseSubscriber{
    public string FullName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}

public class PremiumSubscriber : BaseSubscriber{
   public override void AccessToUnlimitedTitles(){
        base.AccessToUnlimitedTitles();
    }

    public override void GiveAccessToFamilyMembers(){
        base.GiveAccessToFamilyMembers();
    }
}

public class StandardSubscriber : BaseSubscriber{
    public override void AccessToLimitedTitles(){
        base.AccessToLimitedTitles();
    }
}

```

## OPTION 2 
```
public class baseSubscriber: IUserSubscriber {
    public string FullName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}

public class StandardSubscriber : IUserSubscriber, IStandardSubscriber{
    public void AccessToLimitedTitles(){
    }
}

public class PremiumSubscriber : IUserSubscriber, IPremiumSubscriber{
   public void AccessToUnlimitedTitles(){
    }

    public void GiveAccessToFamilyMembers(){
    }
}
```

