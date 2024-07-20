using OpenAI;
using OpenAI.Embeddings;
using System.Numerics.Tensors;

namespace ConsoleOpenAI.Examples;

// Examples: https://github.com/openai/openai-dotnet/tree/main/examples/Embeddings
public static class E05_EmbeddingSimilarity
{
    public static async Task Run(OpenAIClient openAIClient)
    {
        EmbeddingClient embeddingClient = openAIClient.GetEmbeddingClient(OpenAIConfig.Models.Embedding_3_Small);

        List<string> embeddingInputs = [_question, _hotelDescription, _DogDescription];

        EmbeddingCollection collection = await embeddingClient.GenerateEmbeddingsAsync(embeddingInputs);

        ReadOnlyMemory<float> questionEmbedding         = collection[0].Vector;
        ReadOnlyMemory<float> hotelDescriptionEmbedding = collection[1].Vector;
        ReadOnlyMemory<float> dogDescriptionEmbedding   = collection[2].Vector;

        float similarityWithHotel = TensorPrimitives.CosineSimilarity(questionEmbedding.Span, hotelDescriptionEmbedding.Span);
        float similarityWithDog   = TensorPrimitives.CosineSimilarity(questionEmbedding.Span, dogDescriptionEmbedding.Span);

        Console.WriteLine("Similarity with Hotel: {0} Dog: {1}", similarityWithHotel, similarityWithDog);
        // Output: 'Similarity with Hotel: 0,5539474 Dog: 0,056440584'

        Console.WriteLine("--- End of E05_EmbeddingSimilarity ---");
    }

    private const string _question         = "Looking for a hotel with a pool and good location. Around lots of tourist attractions";
    private const string _hotelDescription = "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, and a really helpful concierge. The location is perfect -- right downtown, close to all the tourist attractions. We highly recommend this hotel.";
    private const string _DogDescription   = "Dogs are loyal and loving companions, known for their playful nature and boundless energy. They come in various breeds, each with unique traits and characteristics. Dogs can be great friends, offering comfort and joy to their owners. Their keen senses make them excellent protectors and helpers in various tasks.";
}
