# Aggregation Pipelines
* An aggregate pipeline consists of one or more stages that process documents
  * Each stage performs an operation on this input documents like filter group and calc values
  * The documents that are output from a stage are passed to next stage
  * We can return a result for a single document or a group of documents like average, maximum and minimum values
    ```json
    db.orders.aggregate([
        {
            //stage 1
            $match: {size: "medium"}
        },
        {
            //stage 2
            $group: {_id: "$name"}
        }
    ])
    ```

## How are users are active
* Using mongo operator `match`
*  activeUsers is property name in final output
  
```json
db.users.aggregate([
    {
      $match: {
        isActive: true
        }
    }, 
    {
        $count: "activeUsers"
    }
    
])
```

## What is the average age of all users?
* $gender is field name
* group by null - will give one single document containing everyone in one document
```json
// Grouping people on age
db.users.aggregate([
    {
        $group: {
            _id: "$age"
        }
    }
])

db.users.aggregate([
    {
        $group: {
            _id: null,
            // Accumulators
            averageAge: {
                $avg: "$age"
            }
        }
    }
])
/* output : $averageAge: 29*/
```

## List the top 5 most common favorite fruits among the users

```json
db.users.aggregate([
    {
        $group: {
            _id: "$favouriteFruit"
            // here count is name of field $ is for operator.
            count: {
                $sum: 1 // Here 1 means If you find any user in this group add one to the count
            }
        }
    },
    {
        //Stage 2 : Sorting
        $sort: {
            count: -1 // -1 means descending , 1 is ascending
        }
    },
    {
        // Stage 2: Select top 5
        $limit: 5
    }
])
```

## Find the total numbers of males and females

```json
db.users.aggregate([
    {
        $group: {
            _id: "$gender",
            genderCount: {
                $sum: 1 // or $count: "$gender"
            }
        }
    }
])
```

## Which country has thr highest numbers of registered users?

```json
db.users.aggregate(
[
    {
        $group: {
        _id: "$company.location.country",
        population: {
            $sum: 1
            }
        }
    },
    {
        $sort: {
            population: -1
        }
    },
    {
        $limit: 1
    }

])
```

## List all unique eye color present in the collection
```json
db.users.aggregate([
    {
        $group: {
            _id: "$eyeColor"
        }
    }
])
```

## What is average number of tags per user?
```json
db.users.aggregate([
    {
        // It spreads the array. If we have users with 10 arr values in a property unwind will make 10 documents of that user and each will have one value of the array
        $unwind: "$tags"
    },
    {
        $group: {
            _id: "$name",
            numberOfTags: {
                $sum: 1
            }
        }
    }, 
    {
        $group: {
            _id: null,
            averageTags: {
                $avg: "$numberOfTags"
            }
        }
    }
])
```

 * OR 
```json
db.users.aggregate([
    {
        // Adds a new field
        $addFields: {
            // new field name
            numberOfTags: {
                // gives size of array
                $size: {
                    // $tag may not be present in every document and ifNull lets us handle it , $tag is the field name and if it is null we substitute it with empty array.
                    ifNull: ["$tag", []]
                }
            }
        }
    },
    {
        $group: {
            _id: null,
            averageNumberOfTags: {
                $avg: "$numberOfTags"
            }
        }
    }
])
```

## How many users have `enim` as one of their tags?
```js
db.users.aggregate([
    {
        $match: {
            // Field name & tags is an array
            tags: "enim"
        }
    },
    {
       $count: 'userWithEnimTags'
    }
])
```

## WHat are the names and age of users who are inactive and have `velit` as a tag
```json
db.users.aggregate([
    {
        $match: {
            tags: "velit",
            isActive: false
        }
    },
    {
        // projection
        $project: {
            name: 1, 
            age: 1
        }
    }
])
```

## how many users have phone numbers starting with +1 (940)
```json
db.users.aggregate([
    {
        $match: {
            "company.phone": /^\+1 \(940\)/
        }
    },
    {
        $count: 'usersWithSpecialPhNumber'
    }
])
```

## Who has registered most recently
```json
db.users.aggregate([
    {
        $sort: {
            registeredAt: -1
        }
    },
    {
        $limit: 1
    },
    {
        $project: {
            name: 1,
            age: 1,
            favoriteFruit: 1
        }
    }
])
```

## Categorize users by their favorite fruit
```json
db.users.aggregate([
    {
        $group: {
            _id: "$favoriteFruit",
            users: {
                // push is an accumulator - appends a specific value to array
                $push: "$name"
            }
        }
    }
])
```

## How many users have `ad` as the second tag in their list of tags?
```json
db.users.aggregate([
    {
        $match:{
            // tags array index of 1
            "tags.1": "ad"
        },
        {
            $count: 'secondTagAsAd'
        }
    }
])
```

## Find users who have both enim and id as their tags
```json

db.users.aggregate([
    {
        $match: {
            tags: {
                $all: ["enim", "id"]
            }
        }
    }
])
```

## list all companies located in USA with corresponding user count
```json
db.users.aggregate([
    {
        $match: {
            "company.location.country": "USA"
        }
    },
    {
        $group:{
            _id: "$company.title",
            userCount: {
                $sum: 1
            }
        }
    }
])
```

## 

```json
[
    {
        $lookup: {
            // from which collection
            from: "authors",
            //current local field
            localField: "author_id",
            foreignField: "_id",
            // this will be an array which will have object from the reference of collection. 
            as: "author_details"
        }
    },
    {
        $addFields: {
            author_details: {
                // it can go through into any array and get the first value.
                // we pass form which field we want to get it from
                $first: "author_details"
                // or we can do $arrayElemAt: ["author_details", 0] - 0 is index and author_details is the field. 
            }
        }
    }
]
```