# Playing with Generative AI
This repository contains projects demonstrating the use of AI with Microsoft `Semantic Kernel` and includes a collection of links.

#### Projects in the solution

Prerequisite: the examples use the [OpenAI platform](https://platform.openai.com/api-keys), assuming an environment variable (OpenAI__ApiKey) is present with an API-Key

- ConsoleAppSK
  - KernelInvokePrompt.cs: Simple example of using the `Kernel` by calling the InvokePrompt method
  - ChatCompletion.cs: Using the `IChatCompletionService` with a preserved `ChatHistory`
- WebApiSK
  - Endpoint: '/weather-forecast': Simple example of using the `Kernel` by calling the InvokePrompt method to describe the weather at x°C
  - Endpoint: '/current-time': `IChatCompletionService` getting the current time from a plug-in

#### Resources

- OpeanAI
  - [Playground](https://platform.openai.com/playground) | [Pricing](https://openai.com/api/pricing)
  - [OpenAI .NET API library](https://github.com/openai/openai-dotnet) 👤
  - [Documentation](https://platform.openai.com/docs/overview) | [API reference](https://platform.openai.com/docs/api-reference/introduction)
  - Miscellaneous
    - [Introducint the new library](https://youtu.be/BKeaojX45w0): *ChatClient, ImageClient, AudioClient* - 📽️16 min - Bald.Bearded.Builder
- Semantic Kernel SDK
  - [Documentation](https://learn.microsoft.com/en-us/semantic-kernel/overview) | [API browser](https://learn.microsoft.com/en-us/dotnet/api/?view=semantic-kernel-dotnet) | [Namespace](https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel)
  - [AI for .NET developers](https://learn.microsoft.com/en-us/dotnet/ai) 📚*Microsoft-learn*
  - [Source code](https://github.com/microsoft/semantic-kernel) 👤
  - Miscellaneous
    - [Infusing applications with AI](https://youtu.be/jrNfKeGSuCg) 📽️*46 min - Microsoft Developer | MS Build 2024*
- Azure OpenAI Service
  - [Azure AI Studio](https://ai.azure.com)
  - [Pricing](https://azure.microsoft.com/en-us/pricing/details/cognitive-services/openai-service)
  - [Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/overview)
  - [Azure AI Search](https://learn.microsoft.com/en-us/azure/search/search-what-is-azure-search)
