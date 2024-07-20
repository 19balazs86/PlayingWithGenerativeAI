# Playing with Generative AI
This repository contains projects demonstrating the use of AI with Microsoft `Semantic Kernel SDK` and `OpenAI SDK`.

## Projects in the solution

Prerequisite: the examples use the [OpenAI platform](https://platform.openai.com/api-keys). Assuming an environment variable (OpenAI__ApiKey) is present

#### `SemanticKernel - ConsoleAppSK`

- [E01_KernelInvokePrompt.cs](ConsoleAppSK/Examples/E01_KernelInvokePrompt.cs): Few examples of using the *Kernel* by calling the *InvokePrompt* method
- [E02_ChatWithHistory.cs](ConsoleAppSK/Examples/E02_ChatWithHistory.cs): Using the *IChatCompletionService* with a preserved *ChatHistory*
- [E03_DescribeImage.cs](ConsoleAppSK/Examples/E03_DescribeImage.cs): Using the *IChatCompletionService* to describe an image with *ImageContent(URL)*
- [E04_TextToImage.cs](ConsoleAppSK/Examples/E04_TextToImage.cs): Using the *ITextToImageService* to generate an image
- [E05_EmbeddingSimilarity.cs](ConsoleAppSK/Examples/E05_EmbeddingSimilarity.cs): Use the *ITextEmbeddingGenerationService* to generate embeddings for texts and the *TensorPrimitives.CosineSimilarity* to compare the embedded vectors

#### `SemanticKernel - WebApiSK`

- [Endpoint /weather-forecast](WebApiSK/Endpoints/WeatherForecastEndpoints.cs): Simple example of using the *Kernel* by calling the InvokePrompt method to describe the weather at x°C
- [Endpoint /current-time](WebApiSK/Endpoints/CurrentTimeEndpoints.cs): *IChatCompletionService* getting the current time from a plug-in

#### `OpenAI - ConsoleOpenAI`

- [E01_CompleteChat.cs](ConsoleOpenAI/Examples/E01_CompleteChat.cs): Few simple examples of using the *ChatClient* by calling *CompleteChat* method
- [E02_ChatWithHistory.cs](ConsoleOpenAI/Examples/E02_ChatWithHistory.cs): Using the *ChatClient* with a preserved history
- [E03_DescribeImage.cs](ConsoleOpenAI/Examples/E03_DescribeImage.cs): Using the *ChatClient* to describe an image
- [E04_TextToImage.cs](ConsoleOpenAI/Examples/E04_TextToImage.cs): Using the *ImageClient* to generate an image. Other examples in a comment.
- [E05_EmbeddingSimilarity.cs](ConsoleOpenAI/Examples/E05_EmbeddingSimilarity.cs): Use the *EmbeddingClient* to generate embeddings for texts and the *TensorPrimitives.CosineSimilarity* to compare the embedded vectors

## Resources

#### OpeanAI

- [Playground](https://platform.openai.com/playground) | [Pricing](https://openai.com/api/pricing) | [Tokenizer](https://platform.openai.com/tokenizer) | [Models](https://platform.openai.com/docs/models/overview)
- [OpenAI .NET API library](https://github.com/openai/openai-dotnet), [examples](https://github.com/openai/openai-dotnet/tree/main/examples) 👤
- [Documentation](https://platform.openai.com/docs/overview) | [API reference](https://platform.openai.com/docs/api-reference/introduction)

#### Semantic Kernel SDK

- [Documentation](https://learn.microsoft.com/en-us/semantic-kernel/overview) | [API browser](https://learn.microsoft.com/en-us/dotnet/api/?view=semantic-kernel-dotnet) | [Namespace](https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel)
- [AI for .NET developers](https://learn.microsoft.com/en-us/dotnet/ai) 📚*Microsoft-learn*
- [Source code](https://github.com/microsoft/semantic-kernel), [examples](https://github.com/microsoft/semantic-kernel/tree/main/dotnet) 👤
- Miscellaneous
  - [Infusing applications with AI](https://youtu.be/jrNfKeGSuCg) 📽️*46 min - Microsoft Developer | MS Build 2024*

#### Azure OpenAI Service

- [Azure AI Studio](https://ai.azure.com) | [Pricing](https://azure.microsoft.com/en-us/pricing/details/cognitive-services/openai-service) | [Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/overview)
- [Azure AI Search](https://learn.microsoft.com/en-us/azure/search/search-what-is-azure-search)
- Miscellaneous
  - [Generate images using Azure OpenAI Service](https://code-maze.com/aspnetcore-generate-images-using-openai) (with Azure.AI.OpenAI package) 📓Code-Maze
