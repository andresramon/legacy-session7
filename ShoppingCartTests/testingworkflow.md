Write an acceptance test focused on behaviour // failing for the right reason (behaviour not implemented)

Create interfaces for infrastructure as needed

// Acceptance test should be RED (failing) -> Definition off DONE for behaviour being implemented

// Don’t chase the acceptance test (don´t try to make it pass)



While the acceptance test is failing {

Write a unit test focused on behaviour // failing for the right reason (behaviour not implemented)

While the unit test is failing {

    Implement behaviour to pass the unit test

    Create interfaces for infrastructure as needed

    Commit on green

}

}



Commit // acceptance test should be green at this point -> may need to adjust the acceptance test due to design decision changes



Write integration tests for secondary adapter interfaces // repositories, proxies, message publishers ...

Implement behaviour to pass integration tests // convert from/to infrastructure from/to domain

Commit on green



Write contract tests for primary adapters // HTTP controllers, Message Handlers, ...

Implement behaviour to pass contract tests // convert from/to transport from/to domain

Commit on green



Optionally write End to End tests // Use the transport layer and infrastructure layer on the test (HTTP controllers, queue handlers, ...)

// Probably only need to add configuration to pass

Commit on green



Push